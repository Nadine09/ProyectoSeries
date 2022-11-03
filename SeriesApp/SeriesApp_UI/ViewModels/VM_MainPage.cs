using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

        public VM_MainPage()
        {
            textoQueSeGuarda = "TEXTO INICIAL";
        }

        [RelayCommand]
        void Boton()
        {
            TextoQueSeGuarda = text;
        }
    }
}
