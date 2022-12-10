namespace SeriesApp_DAL.DAO
{
    public class UsersSeriesDAO : GenericAbstractDAO
    {
        private const string GET_BY_SERIES_AND_USER = "SELECT * FROM NAD_UsersSeriesAdd WHERE userId = @userId AND serieId = @seriesId";
        private const string INSERT_BY_SERIES_AND_USER = "INSERT INTO NAD_UsersSeriesAdd (userId, serieId) VALUES (@userId, @seriesId)";

        public bool UserHasSeries(long idUser, long idSerie)
        {
            bool hasSeries;

            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader sqlDataReader = null;

            StartQuery(ref sqlConnection, ref sqlCommand, ref sqlDataReader, GET_BY_SERIES_AND_USER.Replace("@seriesId", idSerie.ToString()).Replace("@userId", idUser.ToString()));

            hasSeries = sqlDataReader.HasRows;

            CloseAll(ref sqlConnection, ref sqlDataReader);

            return hasSeries;
        }

        public void UserAddSeries(long idUser, long idSerie)
        {
            ExecuteNonQuery(INSERT_BY_SERIES_AND_USER.Replace("@seriesId", idSerie.ToString()).Replace("@userId", idUser.ToString()));
        }
    }
}
