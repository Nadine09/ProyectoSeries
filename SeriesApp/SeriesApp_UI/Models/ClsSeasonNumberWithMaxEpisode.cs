using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_UI.Models
{
    public class ClsSeasonNumberWithMaxEpisode
    {
        public int SeasonNumber { get; set; }
        public int EpisodesNumber { get; set; }

        public ClsSeasonNumberWithMaxEpisode()
        {
        }

        public ClsSeasonNumberWithMaxEpisode(int seasonNumber, int episodesNumber)
        {
            SeasonNumber = seasonNumber;
            EpisodesNumber = episodesNumber;
        }
    }
}
