using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SeriesApp_DAL.DAO;
using SeriesApp_Entities.Classes;
using SeriesApp_UI.Views;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_CreateAccount : ObservableObject
    {
        public const string CREATE_ACCOUNT_ERROR = "No se ha podido crear el usuario :(";

        [ObservableProperty]
        string username;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string errorMessage;


        #region Commands
        [RelayCommand]
        async void CreateAccount()
        {
            errorMessage = "";
            UserDAO userDAO = new UserDAO();
            ClsUser user = new ClsUser();
            user.UserName = username;
            user.Email = email;
            user.Password = password;
            
            user = userDAO.CreateUser(user);
            if (user != null)
            {
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
            else
            {
                ErrorMessage = CREATE_ACCOUNT_ERROR;
            }
        }

        #endregion
    }
}
