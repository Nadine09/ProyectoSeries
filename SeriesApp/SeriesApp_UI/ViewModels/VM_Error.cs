using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_Error : VM_Base
    {
        [ObservableProperty]
        string errorMessage = "Lo sentimos, ha ocurrido un error inesperado... ";
    }
}
