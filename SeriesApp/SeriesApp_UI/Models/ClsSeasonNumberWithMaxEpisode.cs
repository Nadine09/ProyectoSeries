using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_UI.Models
{
    /// <summary>
    /// Esta clase contendrá un numero de temporada y su numero total de episodios
    /// </summary>
    public class ClsSeasonNumberWithMaxEpisode
    {
        #region Propiedades
        public int SeasonNumber { get; set; }
        public int EpisodesNumber { get; set; }
        #endregion

        #region Constructores
        public ClsSeasonNumberWithMaxEpisode()
        {
        }

        public ClsSeasonNumberWithMaxEpisode(int seasonNumber, int episodesNumber)
        {
            SeasonNumber = seasonNumber;
            EpisodesNumber = episodesNumber;
        }
        #endregion
    }
}
