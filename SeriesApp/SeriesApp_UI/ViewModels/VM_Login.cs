using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SeriesApp_UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_Login : ObservableObject
    {
        private static string text = "BINDING Funcionaaa !";

        private int number;
        public int Number { get { return number; } set { number = value; } }


        public VM_Login()
        {
            Valor = text;
        }

        public string Valor { get; set; }

        ///////
        ///

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        #region Commands
        [RelayCommand]
        async void Login() {
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }

        #endregion



    }
}
