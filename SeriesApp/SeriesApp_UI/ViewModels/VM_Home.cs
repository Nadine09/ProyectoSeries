﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SeriesApp_UI.ViewModels
{    
    public partial class VM_Home : VM_Base
    {
        #region Propiedades
        private SeriesDAO seriesDAO;

        [ObservableProperty]
        List<ClsSeries> newSeries;

        [ObservableProperty]
        List<ClsSeries> top10Series;
        #endregion

        #region Constructores
        public VM_Home()
        {
            try
            {
                seriesDAO = new SeriesDAO();
                newSeries = seriesDAO.GetAll();
                top10Series = seriesDAO.GetTop10();
            }catch (Exception)
            {
                ShowErrorMessage(DB_ERROR);
            }
        }
        #endregion

        #region Commands
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
        #endregion
    }
}
