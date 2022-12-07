using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leteo_UI.ViewModels
{
    public partial class VM_Home : GenericVM
    {
        [ObservableProperty]
        int u;

        [ObservableProperty]
        string cadena;

        public VM_Home()
        {
            Cadena = "Texto inicial";
        }

        [RelayCommand]
        void CambiarCadena()
        {
            Cadena = "Nueva cadena de texto";
        }

    }
}
