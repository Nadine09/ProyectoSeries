using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_Search : ObservableObject
    {
        private SeriesDAO seriesDAO;

        [ObservableProperty]
        ClsSeries selectedSerie;

        [ObservableProperty]
        string searchText;

        [ObservableProperty]
        List<ClsSeries> searchResult;

        public VM_Search()
        {
            seriesDAO = new SeriesDAO();
            searchResult = seriesDAO.GetAll();
        }

        [RelayCommand]
        public async Task AddSerie(ClsSeries series)
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("Series", series);
            await Shell.Current.GoToAsync("/UsersAddSeriesPage", dictionary);
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
