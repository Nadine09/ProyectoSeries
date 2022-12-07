using Microsoft.Data.SqlClient;

namespace Leteo_DAL.DAO
{
    public class SeriesDAO : GenericDAO<ClsSeries>
    {
        //Constantes
        public const string TABLE_NAME = "NAD_Series";
        public const string TABLE_NAME_USER_SERIES = "NAD_UsersSeriesAdd";
        public const string TABLE_NAME_USER_SERIES_VALUATION = "NAD_UsersSeriesValuation";

        public const string SELECT_ALL = $"SELECT [id], [name], [synopsis], [state], [launchDate], [mra], [valuation], [imageUrl] FROM {TABLE_NAME}";
        public const string SELECT_TOP_10 = $"SELECT TOP(10) [id], [name], [synopsis], [state], [launchDate], [mra], [valuation], [imageUrl] FROM {TABLE_NAME} AS S INNER JOIN (SELECT serieId, (SUM(valuation) / COUNT(valuation)) AS TotalValuation FROM {TABLE_NAME_USER_SERIES_VALUATION} GROUP BY serieId) AS V ON S.id = V.serieId ORDER BY V.TotalValuation DESC";
        public const string SELECT_ALL_SERIES_BY_USER = $"SELECT [id], [name], [synopsis], [state], [launchDate], [mra], [valuation], [imageUrl] FROM {TABLE_NAME} AS S INNER JOIN {TABLE_NAME_USER_SERIES} AS US ON S.id = US.serieId WHERE US.userId = @id";
        public const string INSERT_USER_SERIES = $"INSERT INTO {TABLE_NAME_USER_SERIES} ([serieId], [userId]) VALUES (@serieId, @userId)";

        public SeriesDAO()
        {
            cmdSelectAll = SELECT_ALL;
        }

        public List<ClsSeries> GetTop10()
        {
            return ExecuteQuery(SELECT_TOP_10);
        }

        public List<ClsSeries> GetByUser(long id)
        {
            List<ClsSeries> series = null;
            series = ExecuteQuery(SELECT_ALL_SERIES_BY_USER.Replace("@id", id.ToString()));
            return series;
        }
        public void UserAddSerie(long seriesId, long userId)
        {
            ExecuteNonQuery(INSERT_USER_SERIES.Replace("@serieId", seriesId.ToString()).Replace("@userId", userId.ToString()));
        }

        public override ClsSeries BuildObject(SqlDataReader sqlDataReader)
        {
            ClsSeries serie = new()
            {
                Id = (int)sqlDataReader["id"],
                Name = (string)sqlDataReader["name"],
                ImageUrl = (string)sqlDataReader["imageUrl"]
            };

            //ClsSeries serie = new ClsSeries {
            //    Id = (int)sqlDataReader["id"],
            //    Name = (string)sqlDataReader["name"],
            //    Synopsis = (string)sqlDataReader["synopsis"],
            //    State = (int)sqlDataReader["state"],
            //    LaunchDate = (DateTime)sqlDataReader["launchDate"],
            //    Mra = (int)sqlDataReader["mra"],
            //    Valuation  = (double)sqlDataReader["valuation"],
            //    ImageUrl  = (string)sqlDataReader["imageUrl"]
            //};

            return serie;
        }
    }
}
