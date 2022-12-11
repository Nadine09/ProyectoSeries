using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_UI.Models
{
    public partial class ItemUserSeriesDTO : ObservableObject
    {
        [ObservableProperty]
        ClsSeries series;

        [ObservableProperty]
        int seasonNumber;

        [ObservableProperty]
        int episodeNumber;

        public ItemUserSeriesDTO()
        {
        }

        public ItemUserSeriesDTO(ClsSeries series, int seasonNumber, int episodeNumber)
        {
            Series = series;
            SeasonNumber = seasonNumber;
            EpisodeNumber = episodeNumber;
        }
    }
}
