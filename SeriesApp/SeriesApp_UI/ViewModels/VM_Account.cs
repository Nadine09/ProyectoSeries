using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_Account : ObservableObject
    {
        private UserDAO userDAO;

        [ObservableProperty]
        ClsUser user;

        private long userId;

        public VM_Account()
        {
            //GetUserId();
            userDAO = new UserDAO();
            User = App.Current.User;
            //GetUser();
        }

        private void GetUser()
        {            
            User = userDAO.GetById(userId);
        }

        private async void GetUserId()
        {
            userId = long.Parse(await SecureStorage.Default.GetAsync("Account"));
        }

        [RelayCommand]
        async Task LogoutAsync()
        {
            //await SecureStorage.Default.SetAsync("Account", " ");
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
