using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SeriesApp_UI.ViewModels
{
    //[QueryProperty("User", "User")]
    public partial class VM_Home : VM_Base
    {
        private SeriesDAO seriesDAO;

        [ObservableProperty]
        List<ClsSeries> newSeries;

        [ObservableProperty]
        List<ClsSeries> top10Series;

        public VM_Home()
        {
            seriesDAO = new SeriesDAO();
            newSeries = seriesDAO.GetAll();
            top10Series = seriesDAO.GetTop10();
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
