using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_Search : VM_Base
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

        /// <summary>
        /// Este método navega a UsersAddSeries pasandole la serie recibida por parámetros
        /// </summary>
        /// <param name="series"></param>
        /// <returns></returns>
        [RelayCommand]
        public async Task AddSerie(ClsSeries series)
        {
            try
            {
                var dictionary = new Dictionary<string, object>();
                dictionary.Add("Series", series);
                await Shell.Current.GoToAsync("/UsersAddSeriesPage", dictionary);
            }
            catch (Exception)
            {
                Error();
            }

        }

        /// <summary>
        /// Este método navega a SeriesDetails pasandole la serie recibida por parámetros
        /// </summary>
        /// <param name="series"></param>
        /// <returns></returns>
        [RelayCommand]
        public async Task SeriesDetails(ClsSeries series)
        {
            try
            {
                var dictionary = new Dictionary<string, object>();
                dictionary.Add("Series", series);
                await Shell.Current.GoToAsync("/SeriesDetailsPage", dictionary);
            }
            catch (Exception)
            {
                Error();
            }

        }
    }
}
