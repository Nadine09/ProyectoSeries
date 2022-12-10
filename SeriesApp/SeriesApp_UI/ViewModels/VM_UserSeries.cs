using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_UserSeries : ObservableObject
    {
        [ObservableProperty]
        ClsSeries selectedSerie;

        [ObservableProperty]
        string selectedSerieText;

        [ObservableProperty]
        ObservableCollection<ClsSeries> series;

        private long userId;

        private SeriesDAO seriesDAO;

        public VM_UserSeries()
        {
            GetUserId();
            seriesDAO = new SeriesDAO();
            if (userId != 0)
            {
                List<ClsSeries> userSeries = seriesDAO.GetByUser(userId);
                if (userSeries != null)
                {
                    Series = new ObservableCollection<ClsSeries>(userSeries);
                }
            }
            selectedSerieText = "Sin serie";
        }

        private void GetUserId()
        {
            userId = App.Current.User.Id;
        }

        [RelayCommand]
        void Refresh()
        {
            Series = new ObservableCollection<ClsSeries>(seriesDAO.GetByUser(userId));
        }

        [RelayCommand]
        public async Task EditSerie(ClsSeries series)
        {
            SelectedSerieText = $"Editar serie :: Serie -> Id: {series.Id} Nombre: {series.Name}";
        }

        [RelayCommand]
        public async Task NextEpisode(ClsSeries series)
        {
            SelectedSerieText = $"Siguiente cap :: Serie -> Id: {series.Id} Nombre: {series.Name}";
        }

        [RelayCommand]
        public async Task SeriesDetails(ClsSeries series)
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("Series", series);
            await Shell.Current.GoToAsync("/SeriesDetailsPage", dictionary);
        }
    }
}
