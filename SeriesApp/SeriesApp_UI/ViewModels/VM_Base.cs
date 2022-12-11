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
        [ObservableProperty]
        ClsUser user;

        #region Constructors
        protected VM_Base()
        {
            User = App.Current.User;
        }
        #endregion

        /// <summary>
        /// Este método navega hasta la pantalla anterior
        /// </summary>
        [RelayCommand]
        public async void GoBack()
        {
            try
            {
                //Volvemos atrás
                await Shell.Current.GoToAsync("..");
            }catch (Exception)
            {
                Error();
            }
        }

        protected async void Error()
        {
            //Vamos a la pagina de error
            await Shell.Current.GoToAsync($"//{nameof(ErrorPage)}");
        }
    }
}
