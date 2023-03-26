using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_UI.ViewModels
{
    /// <summary>
    /// Esta es la clase de la que extenderan todos los ViewModels
    /// </summary>
    public abstract partial class VM_Base : ObservableObject
    {
        #region Constantes
        public const string NAVIGATION_ERROR = "Ha ocurrido un error inesperado al intentar navegar hacia otra pantalla. Por favor intentelo de nuevo.";
        public const string DB_ERROR = "Ha ocurrido un error inesperado relacionado con la base de datos. Por favor intentelo de nuevo.";
        public const string GENERIC_ERROR = "Ha ocurrido un error inesperado.";
        #endregion

        #region Propiedades
        [ObservableProperty]
        bool errorMessageVisible;

        [ObservableProperty]
        string errorMessage;
        #endregion

        #region Constructores
        protected VM_Base() {}
        #endregion

        #region Métodos
        /// <summary>
        /// Este método pondrá la propiedad ErrorMessageVisible a false
        /// </summary>
        public void ClearErrorMessage() { ErrorMessageVisible = false; }

        /// <summary>
        /// Este método cambiará el mensaje de error por el pasado por parámetros, además 
        /// de poner a true la propiedad ErrorMessageVisible
        /// </summary>
        /// <param name="message">Será el nuevo valor de ErrorMessage</param>
        public void ShowErrorMessage(string message)
        {
            ErrorMessage = message.Equals(errorMessage) ? "*** " + message : message;
            ErrorMessageVisible = true;
        }

        /// <summary>
        /// Este metodo hará invisible el mensaje de error y después navegará hasta la página 
        /// indicada en el campo url.
        /// </summary>
        /// <param name="url">Direccion a la que se navegará</param>
        public async void Navigate(string url)
        {
            ClearErrorMessage();
            try
            {
                await Shell.Current.GoToAsync(url);
            }
            catch (Exception)
            {
                ShowErrorMessage(NAVIGATION_ERROR);
            }
        }

        /// <summary>
        /// Este metodo hará invisible el mensaje de error y después navegará hasta la página 
        /// indicada en el campo url, pasandole como parámetros dictionary
        /// </summary>
        /// <param name="url">Direccion a la que se navegará</param>
        /// <param name="dictionary">Se pasará como parámetro en la navegación</param>
        public async void Navigate(string url, IDictionary<string, object> dictionary)
        {
            ClearErrorMessage();
            try
            {
                await Shell.Current.GoToAsync(url, dictionary);
            }
            catch (Exception)
            {
                ShowErrorMessage(NAVIGATION_ERROR);
            }
        }

        /// <summary>
        /// Este método navega hasta la pantalla anterior
        /// </summary>
        [RelayCommand]
        public async void GoBack()
        {
            //Volvemos atrás
            Navigate("..");
        }

        /// <summary>
        /// Este método navega hasta la pantalla de error
        /// </summary>
        protected async void Error()
        {
            //Vamos a la pagina de error
            Navigate($"//{nameof(ErrorPage)}");
        }
        #endregion
    }
}
