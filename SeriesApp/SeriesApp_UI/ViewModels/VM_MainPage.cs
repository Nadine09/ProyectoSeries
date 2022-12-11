using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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
