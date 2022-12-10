using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_DAL.DAO
{
    public class UsersEpisodesDAO : GenericAbstractDAO
    {
        private const string TABLE_NAME = "NAD_UsersEpisodes";
        private const string ADD_PROGRESS = $"DECLARE @idEpisode int DECLARE MY_CURSOR CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR SELECT EPI.id FROM NAD_Series AS SER INNER JOIN NAD_Seasons AS SEA ON SER.id = SEA.serieId INNER JOIN NAD_Episodes AS EPI ON SEA.id = EPI.seasonId WHERE SER.id = @idSerie AND (SEA.[order] < @season) OR ((SEA.[order] = @season) AND (EPI.[order] <= @episode)) ORDER BY SEA.[order], EPI.[order] OPEN MY_CURSOR FETCH NEXT FROM MY_CURSOR INTO @idEpisode WHILE @@FETCH_STATUS = 0 BEGIN    INSERT INTO {TABLE_NAME} (episodeId, userId) VALUES (@idEpisode, @userId) FETCH NEXT FROM MY_CURSOR INTO @idEpisode END CLOSE MY_CURSOR DEALLOCATE MY_CURSOR";
        private const string GET_LAST_EPISODE_ORDER = "SELECT MAX(E.[order]) AS Episode, SEA.[order] AS Season FROM NAD_UsersEpisodes AS UE INNER JOIN NAD_Episodes AS E ON UE.episodeId = E.id INNER JOIN NAD_Seasons AS SEA ON E.seasonId = SEA.id WHERE UE.userId = @userId AND SEA.serieId = @serieId AND SEA.[order] = (SELECT MAX(SEA.[order]) AS Season FROM NAD_UsersEpisodes AS UE INNER JOIN NAD_Episodes AS E ON UE.episodeId = E.id INNER JOIN NAD_Seasons AS SEA ON E.seasonId = SEA.id WHERE UE.userId = @userId AND SEA.serieId = @serieId) GROUP BY SEA.[order]";
        private const string UPDATE_PROGRESS = "DECLARE @idEpisode int DECLARE MY_CURSOR CURSOR LOCAL STATIC READ_ONLY FORWARD_ONLY FOR @query OPEN MY_CURSOR FETCH NEXT FROM MY_CURSOR INTO @idEpisode WHILE @@FETCH_STATUS = 0 BEGIN @instruction FETCH NEXT FROM MY_CURSOR INTO @idEpisode  END CLOSE MY_CURSOR DEALLOCATE MY_CURSOR";
        private const string UPDATE_PROGRESS_QUERY_ONE_SEASON = "SELECT EPI.id FROM NAD_Series AS SER INNER JOIN NAD_Seasons AS SEA ON SER.id = SEA.serieId INNER JOIN NAD_Episodes AS EPI ON SEA.id = EPI.seasonId WHERE SER.id = @idSerie AND SEA.[order] = @season AND EPI.[order] BETWEEN @minEpisode+1 AND @maxEpisode ORDER BY SEA.[order], EPI.[order]";
        private const string UPDATE_PROGRESS_QUERY_SOME_SEASONS = "SELECT EPI.id FROM NAD_Series AS SER INNER JOIN NAD_Seasons AS SEA ON SER.id = SEA.serieId INNER JOIN NAD_Episodes AS EPI ON SEA.id = EPI.seasonId WHERE SER.id = @idSerie AND ( (SEA.[order] = @minSeason AND EPI.[order] > @minEpisode) OR (SEA.[order] = @maxSeason AND EPI.[order] <= @maxEpisode) OR (SEA.[order] > @minSeason AND SEA.[order] < @maxSeason) ) ORDER BY SEA.[order], EPI.[order]";
        private const string UPDATE_PROGRESS_INSERT = "INSERT INTO NAD_UsersEpisodes (episodeId, userId) VALUES (@idEpisode, @userId)";
        private const string UPDATE_PROGRESS_DELETE = "DELETE FROM NAD_UsersEpisodes WHERE episodeId = @idEpisode AND userId = @userId";

        /// <summary>
        /// Este método inserta en la tabla NAD_UsersEpisodes una fila por cada episodio que el usuario a visto.
        /// Se usan los parámetros season y episode para saber cúal es el último episodio que a visto.
        /// </summary>
        /// <param name="idSerie">Id de la serie</param>
        /// <param name="season">Temporada del último episodio que ha visto</param>
        /// <param name="episode">Último episodio que ha visto el usuario</param>
        /// <param name="userId">Id del usuario</param>
        public void AddProgress(long idSerie, long season, long episode, long userId)
        {
            ExecuteNonQuery(ADD_PROGRESS.Replace("@idSerie", idSerie.ToString()).Replace("@season", season.ToString()).Replace("@episode", episode.ToString()).Replace("@userId", userId.ToString()));
        }

        public void LastEpisode(long idUser, long idSerie, ref int season, ref int episode)
        {
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader sqlDataReader = null;

            StartQuery(ref sqlConnection, ref sqlCommand, ref sqlDataReader, GET_LAST_EPISODE_ORDER.Replace("@serieId", idSerie.ToString()).Replace("@userId", idUser.ToString()));

            if (sqlDataReader.HasRows)
            {
                //Nos movemos hasta la fila y la leemos
                if (sqlDataReader.Read())
                {

                    episode = (int)(short)sqlDataReader["Episode"];
                    season = (int)(short)sqlDataReader["Season"];
                }
            }

            CloseAll(ref sqlConnection, ref sqlDataReader);
        }

        public void UpdateProgress(long idSerie, long season, long minEpisode, long maxEpisode, long userId, bool increasedProgress)
        {
            ExecuteNonQuery(UPDATE_PROGRESS
                .Replace("@query", UPDATE_PROGRESS_QUERY_ONE_SEASON)
                .Replace("@instruction", increasedProgress? UPDATE_PROGRESS_INSERT : UPDATE_PROGRESS_DELETE)
                .Replace("@idSerie", idSerie.ToString())
                .Replace("@season", season.ToString())
                .Replace("@minEpisode", increasedProgress ? minEpisode.ToString() : maxEpisode.ToString())
                .Replace("@maxEpisode", increasedProgress ? maxEpisode.ToString() : maxEpisode.ToString())
                .Replace("@userId", userId.ToString()));
        }

        public void UpdateProgress(long idSerie, long minSeason, long maxSeason, long minEpisode, long maxEpisode, long userId, bool increasedProgress)
        {
            ExecuteNonQuery(UPDATE_PROGRESS
                .Replace("@query", UPDATE_PROGRESS_QUERY_SOME_SEASONS)
                .Replace("@instruction", increasedProgress ? UPDATE_PROGRESS_INSERT : UPDATE_PROGRESS_DELETE)
                .Replace("@idSerie", idSerie.ToString())
                .Replace("@minSeason", increasedProgress? minSeason.ToString() : maxSeason.ToString())
                .Replace("@maxSeason", increasedProgress? maxSeason.ToString() : minSeason.ToString())
                .Replace("@minEpisode", increasedProgress ? minEpisode.ToString() : maxEpisode.ToString())
                .Replace("@maxEpisode", increasedProgress ? maxEpisode.ToString() : maxEpisode.ToString())
                .Replace("@userId", userId.ToString()));
        }
    }
}
