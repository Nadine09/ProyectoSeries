using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_UI.ViewModels
{
    public abstract partial class VM_Base : ObservableObject
    {
        public const string NAVIGATION_ERROR = "Ha ocurrido un error inesperado al intentar navegar hacia otra pantalla. Por favor intentelo de nuevo.";
        public const string DB_ERROR = "Ha ocurrido un error inesperado relacionado con la base de datos. Por favor intentelo de nuevo.";
        public const string GENERIC_ERROR = "Ha ocurrido un error inesperado.";

        [ObservableProperty]
        bool errorMessageVisible;

        [ObservableProperty]
        string errorMessage;

        #region Constructors
        protected VM_Base() {}
        #endregion

        public void ClearErrorMessage() { ErrorMessageVisible = false; }

        public void ShowErrorMessage(string message)
        {
            ErrorMessage = message.Equals(errorMessage) ? "*** " + message : message;
            ErrorMessageVisible = true;
        }

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
            await Shell.Current.GoToAsync($"//{nameof(ErrorPage)}");
        }
    }
}
