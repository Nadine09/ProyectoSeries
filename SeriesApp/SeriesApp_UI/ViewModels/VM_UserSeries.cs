using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.IdentityModel.Tokens;
using SeriesApp_UI.Utils;
using System.Collections.ObjectModel;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_UserSeries : VM_Base
    {
        [ObservableProperty]
        ClsSeries selectedSerie;

        [ObservableProperty]
        ObservableCollection<ItemUserSeriesDTO> series;

        private SeriesDAO seriesDAO;
        private SeriesConverter converter;

        public VM_UserSeries() : base()
        {
            seriesDAO = new SeriesDAO();
            converter = new SeriesConverter();
            if (User.Id != 0)
            {
                Refresh();
            }
        }

        [RelayCommand]
        void Refresh()
        {
            List<ClsSeries> userSeries = seriesDAO.GetByUser(User.Id);
            if (!userSeries.IsNullOrEmpty())
            {
                Series = new ObservableCollection<ItemUserSeriesDTO>();
                userSeries.ForEach(x => Series.Add(converter.ConvertToItemUserSeriesDTO(x, User.Id)));
            }
        }

        [RelayCommand]
        public async Task EditSerie(ItemUserSeriesDTO itemUserSeriesDTO)
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("Series", itemUserSeriesDTO.Series);
            await Shell.Current.GoToAsync("/UsersAddSeriesPage", dictionary);
        }

        [RelayCommand]
        public async Task NextEpisode(ItemUserSeriesDTO itemUserSeriesDTO)
        {
            //TODO Hacer que el progreso se incremente en 1 episodio
        }

        [RelayCommand]
        public async Task SeriesDetails(ItemUserSeriesDTO itemUserSeriesDTO)
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("Series", itemUserSeriesDTO.Series);
            await Shell.Current.GoToAsync("/SeriesDetailsPage", dictionary);
        }
    }
}
