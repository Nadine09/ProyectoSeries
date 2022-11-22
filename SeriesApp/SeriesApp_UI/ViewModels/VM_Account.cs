using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SeriesApp_DAL.DAO;
using SeriesApp_Entities.Classes;
using SeriesApp_UI.Views;

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
            GetUserId();
            userDAO = new UserDAO();
            GetUser();
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
        void Refresh()
        {
            GetUser();
        }

        [RelayCommand]
        async Task LogoutAsync()
        {
            //await SecureStorage.Default.SetAsync("Account", " ");
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}
