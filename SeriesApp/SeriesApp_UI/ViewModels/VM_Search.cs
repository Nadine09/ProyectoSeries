using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using static System.Net.Mime.MediaTypeNames;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_Search : VM_Base
    {
        private SeriesDAO seriesDAO;

        [ObservableProperty]
        ClsSeries selectedSerie;

        [ObservableProperty]
        string searchText;
        
        /// <summary>
        /// Este método se ejecutará cuando la cadena SearchText cambie. Si esta está vacía o es nula se actualizará la lista de series para contenerlas todas.
        /// 
        /// ACLARACIÓN: Esto he tenido que hacerlo porque el Search Bar sólo llama al commando enlazado cuando la búsqueda contiene texto,
        /// cuando está vacía o únicamente contiene espacios en blanco no se actualizaría.
        /// </summary>
        /// <param name="value"></param>
        partial void OnSearchTextChanged(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                SearchResult = AllSeriesList; // TODO mirar que se hace una copia, no sobreescribe
            }
        }

        [ObservableProperty]
        List<ClsSeries> searchResult;

        List<ClsSeries> AllSeriesList;// privada

        public VM_Search()
        {
            try
            {
                seriesDAO = new SeriesDAO();
                AllSeriesList = seriesDAO.GetAll();
                SearchResult = AllSeriesList;
            }
            catch (Exception)
            {
                ShowErrorMessage(DB_ERROR);
            }
        }

        /// <summary>
        /// Este método es ejecutado cuando el usuario pulsa en el botón de búsqueda y el texto introducido no es nulo, 
        /// ni está vacío, ni contiene unicamente espacios en blanco. 
        /// 
        /// Se actualizará la lista de series SearchResult con las series que contengan en su nombre el texto de la búsqueda.
        /// </summary>
        [RelayCommand]
        public async void SearchSerie()
        {
            SearchResult = AllSeriesList.Where(x => x.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase)).ToList();
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
                Navigate("/UsersAddSeriesPage", dictionary);
            }
            catch (Exception)
            {
                ShowErrorMessage(GENERIC_ERROR);
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
                Navigate("/SeriesDetailsPage", dictionary);
            }
            catch (Exception)
            {
                ShowErrorMessage(GENERIC_ERROR);
            }

        }
    }
}
