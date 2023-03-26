 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_UI.Utils
{
    public class SeriesConverter
    {
        #region Propiedades
        private SeriesDAO seriesDAO;
        private UsersEpisodesDAO usersEpisodesDAO;
        #endregion

        #region Constructores
        public SeriesConverter()
        {
            seriesDAO = new SeriesDAO();
            usersEpisodesDAO = new UsersEpisodesDAO();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Este método convierte la serie pasada por parámetros en un objeto de la clase 
        /// ClsSeriesWithEpisodesPerSeason y lo devuelve.<br/>
        /// <br/>
        /// <b>IMPORTANTE: Este método llama a la capa DAL y no se hace responsable de las excepciones que se puedan lanzar</b>
        /// </summary>
        /// <param name="series">Serie que se convertirá a ClsSeriesWithEpisodesPerSeason</param>
        /// <returns></returns>
        public ClsSeriesWithEpisodesPerSeason ConvertToSeriesWithEpisodesPerSeason(ClsSeries series)
        {
            List<ClsSeasonNumberWithMaxEpisode> list = new List<ClsSeasonNumberWithMaxEpisode>();
            seriesDAO.episodesPerSeason(series.Id).ForEach(x => list.Add(new ClsSeasonNumberWithMaxEpisode(x[0], x[1])));
            return new ClsSeriesWithEpisodesPerSeason(series, list);
        }

        /// <summary>
        /// Este método convierte la serie pasada por parametros en un objeto de la clase ItemUserSeriesDTO. 
        /// Se usará userId para ello.<br/>
        /// <br/>
        /// <b>IMPORTANTE: Este método llama a la capa DAL y no se hace responsable de las excepciones que se puedan lanzar</b>
        /// </summary>
        /// <param name="series">Serie que se convertirá a ItemUserSeriesDTO</param>
        /// <param name="userId">Id de usuario que se usará para buscar los datos del episodio y la temporada</param>
        /// <returns></returns>
        public ItemUserSeriesDTO ConvertToItemUserSeriesDTO(ClsSeries series, long userId)
        {
            int season = 0, episode = 0;
            usersEpisodesDAO.LastEpisode(userId, series.Id, ref season, ref episode);
            return new ItemUserSeriesDTO(series, season, episode);
        }
        #endregion
    }
}
