using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LeteoApp_UI.ViewModels;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_Account : VM_Observer
    {
        #region Constructores
        public VM_Account() : base() {}
        #endregion

        #region Commands
        /// <summary>
        /// Este método hace que se navege hacia la pagina Login
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        async Task LogoutAsync()
        {
            Navigate($"//{nameof(LoginPage)}");
        }
        #endregion
    }
}
