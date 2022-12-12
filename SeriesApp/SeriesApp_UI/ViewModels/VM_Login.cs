using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.IdentityModel.Tokens;
using System.Collections.ObjectModel;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_Login : VM_Base
    {
        private UserDAO userDAO;

        public const string EMPTY_FIELDS = "Los campos no pueden estar vacíos";
        public const string LOGIN_ERROR = "No se ha podido hacer login, revisa los datos e intentalo de nuevo";

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string errorMessage;

        public VM_Login()
        {
            userDAO = new UserDAO();
        }

        #region Commands

        /// <summary>
        /// Este metodo valida los datos e intenta iniciar sesión. Si lo consigue navega a la pagina Home
        /// </summary>
        [RelayCommand]
        async void Login()
        {
            try
            {
                errorMessage = "";

                //Comprobamos que los campos no estén vacios
                if (!Email.IsNullOrEmpty() && !Password.IsNullOrEmpty())
                {
                    //Obtenemos el usuario con ese email y password
                    User = userDAO.GetUserByEmailAndPassword(Email, Password);

                    if (User != null)
                    {
                        App.Current.Restart();
                        App.Current.User = User;
                        await Shell.Current.GoToAsync("//HomePage");
                    }
                    else
                    {
                        ErrorMessage = LOGIN_ERROR;
                    }
                }
                else
                {
                    ErrorMessage = EMPTY_FIELDS;
                }
            }
            catch (Exception)
            {
                Error();
            }
        }


        /// <summary>
        /// Este método navega hacia la pagina CreateAccount
        /// </summary>
        [RelayCommand]
        async void CreateAccount()
        {
            try
            {
                await Shell.Current.GoToAsync($"//{nameof(CreateAccountPage)}");
            }
            catch (Exception)
            {
                Error();
            }
        }
        #endregion

    }
}
