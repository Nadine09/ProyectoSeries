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
    }
}
