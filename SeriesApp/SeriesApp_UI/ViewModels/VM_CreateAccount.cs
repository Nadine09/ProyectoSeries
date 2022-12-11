using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_CreateAccount : VM_Base
    {
        public const string CREATE_ACCOUNT_ERROR = "No se ha podido crear el usuario";

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
            try
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
            catch (Exception)
            {
                Error();
            }
        }

        [RelayCommand]
        public async void BackToLogin()
        {
            //Volvemos atrás
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
        #endregion
    }
}
