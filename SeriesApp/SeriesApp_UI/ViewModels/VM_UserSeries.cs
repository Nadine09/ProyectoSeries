using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LeteoApp_UI.ViewModels;
using Microsoft.IdentityModel.Tokens;
using SeriesApp_UI.Utils;
using System.Collections.ObjectModel;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_UserSeries : VM_Observer
    {
        #region Propiedades
        [ObservableProperty]
        ClsSeries selectedSerie;

        [ObservableProperty]
        ObservableCollection<ItemUserSeriesDTO> series;

        private SeriesDAO seriesDAO;
        private SeriesConverter converter;
        #endregion

        #region Constructores
        public VM_UserSeries() : base()
        {            
            seriesDAO = new SeriesDAO();
            converter = new SeriesConverter();
            Series = new ObservableCollection<ItemUserSeriesDTO>();
        }
        #endregion

        #region Commands
        /// <summary>
        /// Este metodo obtiene las series de las que es usuario ya tiene progreso guardado y actualiza el listado Series
        /// </summary>
        [RelayCommand]
        void Refresh()
        {
            if (User.Id != 0)
            {
                try
                {
                    List<ClsSeries> userSeries = seriesDAO.GetByUser(User.Id);
                    series.Clear();
                    if (!userSeries.IsNullOrEmpty())
                    {                        
                        userSeries.ForEach(x => Series.Add(converter.ConvertToItemUserSeriesDTO(x, User.Id)));
                    }
                }
                catch (Exception)
                {
                    ShowErrorMessage(DB_ERROR);
                }
            }
        }

        /// <summary>
        /// Este método navega a UsersAddSeries pasandole la serie recibida por parámetros
        /// </summary>
        /// <param name="itemUserSeriesDTO"></param>
        /// <returns></returns>
        [RelayCommand]
        public async Task EditSerie(ItemUserSeriesDTO itemUserSeriesDTO)
        {
            try
            {
                var dictionary = new Dictionary<string, object>();
                dictionary.Add("Series", itemUserSeriesDTO.Series);
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
        /// <param name="itemUserSeriesDTO"></param>
        /// <returns></returns>
        [RelayCommand]
        public async Task SeriesDetails(ItemUserSeriesDTO itemUserSeriesDTO)
        {
            try
            {
                var dictionary = new Dictionary<string, object>();
                dictionary.Add("Series", itemUserSeriesDTO.Series);
                Navigate("/SeriesDetailsPage", dictionary);
            }
            catch (Exception)
            {
                ShowErrorMessage(GENERIC_ERROR);
            }
        }
        #endregion
    }
}
