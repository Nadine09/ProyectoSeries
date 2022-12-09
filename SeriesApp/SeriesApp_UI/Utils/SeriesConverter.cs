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

        public SeriesConverter()
        {
            seriesDAO = new SeriesDAO();
        }

        public ClsSeriesWithEpisodesPerSeason ConvertToSeriesWithEpisodesPerSeason(ClsSeries series)
        {
            List<ClsSeasonNumberWithMaxEpisode> list = new List<ClsSeasonNumberWithMaxEpisode>();
            seriesDAO.episodesPerSeason(series.Id).ForEach(x => list.Add(new ClsSeasonNumberWithMaxEpisode(x[0], x[1])));
            return new ClsSeriesWithEpisodesPerSeason(series, list);
        }
    }
}
