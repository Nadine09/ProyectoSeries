using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SeriesApp_UI.ViewModels
{
    [QueryProperty("Series", "Series")]
    public partial class VM_SeriesDetails : VM_Base, IQueryAttributable
    {
        #region Propiedades
        [ObservableProperty]
        ClsSeries series;
        #endregion

        #region Constructores
        public VM_SeriesDetails() {}
        #endregion

        #region Métodos
        /// <summary>
        /// Este método recoge los parámetros dados al navegar hasta la pagina
        /// </summary>
        /// <param name="query">IDictionary de donde se recogerán los parámetros</param>
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Object obj;
            bool hasValue = query.TryGetValue("Series", out obj);

            if (hasValue)
            {
                Series = (ClsSeries)obj;
            }
            else
            {
                ShowErrorMessage(GENERIC_ERROR);
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Este método navega a UsersAddSeries pasandole la serie
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        public async Task AddSerie()
        {
            try
            {
                var dictionary = new Dictionary<string, object>();
                dictionary.Add("Series", Series);
                Navigate("/UsersAddSeriesPage", dictionary);
            }
            catch (Exception)
            {
                ShowErrorMessage(GENERIC_ERROR);
            }

        }
        #endregion
    }
}
