using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_Account : VM_Base
    {

        public VM_Account() : base()
        {

        }

        /// <summary>
        /// Este método hace que se navege hacia la pagina Login
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        async Task LogoutAsync()
        {
            try
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            catch (Exception)
            {
                Error();
            }
        }
    }
}
