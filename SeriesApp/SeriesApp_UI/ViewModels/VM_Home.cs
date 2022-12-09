using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SeriesApp_UI.ViewModels
{
    //[QueryProperty("User", "User")]
    public partial class VM_Home : ObservableObject
    {
        private SeriesDAO seriesDAO;

        [ObservableProperty]
        List<ClsSeries> newSeries;

        [ObservableProperty]
        List<ClsSeries> top10Series;

        [ObservableProperty]
        ClsUser user;

        public VM_Home()
        {
            seriesDAO = new SeriesDAO();
            newSeries = seriesDAO.GetAll();
            top10Series = seriesDAO.GetTop10();
        }

        [RelayCommand]
        void Refresh()
        {
            newSeries = seriesDAO.GetAll();
            Top10Series = seriesDAO.GetTop10();
        }

        [ObservableProperty]
        long serieId;

        [RelayCommand]
        void AddSerie()
        {
            SerieId = 1;
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
