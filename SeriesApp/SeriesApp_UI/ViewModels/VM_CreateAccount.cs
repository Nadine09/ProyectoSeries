using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.IdentityModel.Tokens;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_CreateAccount : VM_Base
    {
        public const string CREATE_ACCOUNT_ERROR = "No se ha podido crear el usuario";
        public const string INVALID_EMAIL = "El email ya está en uso, prueba con otro o inicia sesión";
        public const string CREATE_ACCOUNT_EMPTY_FIELDS = "Los campos no pueden estar vacíos";

        [ObservableProperty]
        string username;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string errorMessage;

        private UserDAO userDAO;

        public VM_CreateAccount()
        {
            userDAO = new UserDAO();
        }

        /// <summary>
        /// Este método valida los datos de registro (Username, Email y Password) y si son válidos intenta crear un usuario.
        /// Si se consigue se navegará a Home.
        /// </summary>
        #region Commands
        [RelayCommand]
        async void CreateAccount()
        {
            try
            {
                errorMessage = "";

                if (!Username.IsNullOrEmpty() && !Email.IsNullOrEmpty() && !Password.IsNullOrEmpty())
                {
                    if (userDAO.ValidateEmail(Email))
                    {

                        //Intentamos crear el nuevo usuario
                        ClsUser newUser = new ClsUser(Username, Email, Password);
                        newUser = userDAO.CreateUser(newUser);

                        if (newUser != null && newUser.Id != 0)
                        {
                            await Shell.Current.GoToAsync("//HomePage");
                        }
                        else
                        {
                            ErrorMessage = CREATE_ACCOUNT_ERROR;
                        }
                    }
                    else
                    {
                        ErrorMessage = INVALID_EMAIL;
                    }
                }
                else
                {
                    ErrorMessage = CREATE_ACCOUNT_EMPTY_FIELDS;
                }
            }
            catch (Exception)
            {
                Error();
            }
        }

        /// <summary>
        /// Este metodo navega a la pagina Login
        /// </summary>
        [RelayCommand]
        public async void BackToLogin()
        {
            try
            {
                //Volvemos atrás
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            catch (Exception)
            {
                Error();
            }
        }
        #endregion
    }
}
