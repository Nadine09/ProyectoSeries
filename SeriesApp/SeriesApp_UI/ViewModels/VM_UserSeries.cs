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

        

        /// <summary>
        /// Este metodo obtiene las series de las que es usuario ya tiene progreso guardado
        /// </summary>
        [RelayCommand]
        void Refresh()
        {
            try
            {
                List<ClsSeries> userSeries = seriesDAO.GetByUser(User.Id);
                if (!userSeries.IsNullOrEmpty())
                {
                    Series = new ObservableCollection<ItemUserSeriesDTO>();
                    userSeries.ForEach(x => Series.Add(converter.ConvertToItemUserSeriesDTO(x, User.Id)));
                }
            }
            catch (Exception)
            {
                ShowErrorMessage(DB_ERROR);
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
        /// Este metodo suma 1 al progreso
        /// </summary>
        /// <param name="itemUserSeriesDTO"></param>
        /// <returns></returns>
        [RelayCommand]
        public async Task NextEpisode(ItemUserSeriesDTO itemUserSeriesDTO)
        {
            //TODO Hacer que el progreso se incremente en 1 episodio
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
                await Shell.Current.GoToAsync("/SeriesDetailsPage", dictionary);
            }
            catch (Exception)
            {
                Error();
            }
        }
    }
}
