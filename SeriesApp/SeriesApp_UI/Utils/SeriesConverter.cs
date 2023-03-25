 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_UI.Utils
{
    public class SeriesConverter
    {
        private SeriesDAO seriesDAO;
        private UsersEpisodesDAO usersEpisodesDAO;

        public SeriesConverter()
        {
            seriesDAO = new SeriesDAO();
            usersEpisodesDAO = new UsersEpisodesDAO();
        }

        public ClsSeriesWithEpisodesPerSeason ConvertToSeriesWithEpisodesPerSeason(ClsSeries series)
        {
            List<ClsSeasonNumberWithMaxEpisode> list = new List<ClsSeasonNumberWithMaxEpisode>();
            seriesDAO.episodesPerSeason(series.Id).ForEach(x => list.Add(new ClsSeasonNumberWithMaxEpisode(x[0], x[1])));
            return new ClsSeriesWithEpisodesPerSeason(series, list);
        }
        
        public ItemUserSeriesDTO ConvertToItemUserSeriesDTO(ClsSeries series, long userId)
        {
            int season = 0, episode = 0;
            usersEpisodesDAO.LastEpisode(userId, series.Id, ref season, ref episode);
            return new ItemUserSeriesDTO(series, season, episode);
        }
    }
}
