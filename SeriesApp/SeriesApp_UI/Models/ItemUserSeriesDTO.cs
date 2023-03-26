using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_UI.Models
{
    /// <summary>
    /// Esta clase se usará para almacenar una serie y el último capítulo que ha visto un usuario de esta
    /// </summary>
    public partial class ItemUserSeriesDTO : ObservableObject
    {
        #region Propiedades
        [ObservableProperty]
        ClsSeries series;

        [ObservableProperty]
        int seasonNumber;

        [ObservableProperty]
        int episodeNumber;
        #endregion

        #region Constructores
        public ItemUserSeriesDTO()
        {
        }

        public ItemUserSeriesDTO(ClsSeries series, int seasonNumber, int episodeNumber)
        {
            Series = series;
            SeasonNumber = seasonNumber;
            EpisodeNumber = episodeNumber;
        }
        #endregion
    }
}
