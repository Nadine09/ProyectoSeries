namespace SeriesApp_DAL.DAO
{
    public class SeriesDAO : GenericDAO<ClsSeries>
    {
        //Constantes
        public const string TABLE_NAME = "NAD_Series";
        public const string TABLE_NAME_USER_SERIES = "NAD_UsersSeriesAdd";
        public const string TABLE_NAME_USER_SERIES_VALUATION = "NAD_UsersSeriesValuation";

        public const string SELECT_ALL = $"SELECT [id], [name], [synopsis], [state], [launchDate], [mra], [valuation], [imageUrl] FROM {TABLE_NAME}";
        public const string SELECT_BY_ID = $"SELECT [id], [name], [synopsis], [state], [launchDate], [mra], [valuation], [imageUrl] FROM {TABLE_NAME} WHERE Id = @id";
        public const string SELECT_TOP_10 = $"SELECT TOP(10) [id], [name], [synopsis], [state], [launchDate], [mra], [valuation], [imageUrl] FROM {TABLE_NAME} AS S INNER JOIN (SELECT serieId, (SUM(valuation) / COUNT(valuation)) AS TotalValuation FROM {TABLE_NAME_USER_SERIES_VALUATION} GROUP BY serieId) AS V ON S.id = V.serieId ORDER BY V.TotalValuation DESC";
        public const string SELECT_ALL_SERIES_BY_USER = $"SELECT [id], [name], [synopsis], [state], [launchDate], [mra], [valuation], [imageUrl] FROM {TABLE_NAME} AS S INNER JOIN {TABLE_NAME_USER_SERIES} AS US ON S.id = US.serieId WHERE US.userId = @id";
        public const string INSERT_USER_SERIES = $"INSERT INTO {TABLE_NAME_USER_SERIES} ([serieId], [userId]) VALUES (@serieId, @userId)";
        public const string GET_EPISODES_PER_SEASON = $"SELECT (SEA.[order]) AS SeasonNumber, (MAX (EPI.[order])) AS Episodes FROM NAD_Series AS SER INNER JOIN NAD_Seasons AS SEA ON SER.id = SEA.serieId INNER JOIN NAD_Episodes AS EPI ON SEA.id = EPI.seasonId WHERE SER.id = @idSerie GROUP BY SEA.[order] ORDER BY SEA.[order]";

        public SeriesDAO()
        {
            cmdSelectAll = SELECT_ALL;
            cmdSelectById = SELECT_BY_ID;
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

        public List<int[]> episodesPerSeason(long idSerie)
        {
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader sqlDataReader = null;
            List<int[]> seasonEpisodes = new List<int[]>();

            StartQuery(ref sqlConnection, ref sqlCommand, ref sqlDataReader, GET_EPISODES_PER_SEASON.Replace("@idSerie", idSerie.ToString()));

            //Miramos si hay alguna fila
            if (sqlDataReader.HasRows)
            {
                //Mientras siga teniendo filas nos movemos hasta la fila y la leemos
                while (sqlDataReader.Read())
                {
                    //Construimos el objeto y lo añadimos a la lista
                    seasonEpisodes.Add(new int[] { (int)(short)sqlDataReader["SeasonNumber"], (int)(short)sqlDataReader["Episodes"] });
                }
            }

            CloseAll(ref sqlConnection, ref sqlDataReader);


            //Devolvemos la lista de objetos
            return seasonEpisodes;
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
