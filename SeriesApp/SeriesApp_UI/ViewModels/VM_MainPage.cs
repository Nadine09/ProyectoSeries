using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SeriesApp_Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_MainPage : ObservableObject
    {
        [ObservableProperty]
        string text;

        [ObservableProperty]
        string textoQueSeGuarda;

        [ObservableProperty]
        ClsUser user;

        public VM_MainPage()
        {
            textoQueSeGuarda = "TEXTO INICIAL";
            User = new();
        }

        [RelayCommand]
        void Boton()
        {
            TextoQueSeGuarda = text;
        }
        
        [RelayCommand]
        async Task GetUserAsync()
        {
            User.UserName = await SecureStorage.Default.GetAsync("Account");
        }
    }
}
