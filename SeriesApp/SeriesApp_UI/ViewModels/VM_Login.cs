using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SeriesApp_DAL.DAO;
using SeriesApp_Entities.Classes;
using SeriesApp_UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_Login : ObservableObject
    {

        public const string LOGIN_ERROR = "No se ha podido hacer login :(";

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string errorMessage;

        #region Commands
        [RelayCommand]
        async void Login()
        {
            errorMessage = "";
            UserDAO userDAO = new UserDAO();
            ClsUser user = userDAO.GetUserByEmailAndPassword(email, password);
            if (user != null)
            {
                await SecureStorage.Default.SetAsync("Account", user.Id.ToString());
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}?", new Dictionary<string, object>
                {
                    ["UserId"] = user
                });
            }
            else
            {
                ErrorMessage = LOGIN_ERROR;
            }
        }

        [RelayCommand]
        async void CreateAccount()
        {
            await Shell.Current.GoToAsync($"//{nameof(CreateAccountPage)}");
        }

        #endregion

        [ObservableProperty]
        long id;

        [RelayCommand]
        async Task GetUserAsync()
        {
            Id = long.Parse(await SecureStorage.Default.GetAsync("Account"));
        }

    }
}
