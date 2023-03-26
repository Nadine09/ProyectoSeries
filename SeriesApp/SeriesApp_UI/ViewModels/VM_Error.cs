using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_Error : ObservableObject
    {
        #region Constantes
        public const string ERROR = "Lo sentimos, ha ocurrido un error inesperado... ";
        #endregion

        #region Propiedades
        [ObservableProperty]
        string errorMessage;
        #endregion

        #region Constructores
        public VM_Error()
        {
            errorMessage = ERROR;
        }
        #endregion

    }
}
