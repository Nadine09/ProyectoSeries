using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LeteoApp_UI.Classes;
using LeteoApp_UI.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Collections.ObjectModel;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_Login : VM_Base
    {

        #region Constantes
        public const string EMPTY_FIELDS = "Los campos no pueden estar vacíos";
        public const string LOGIN_ERROR = "No se ha podido hacer login, revisa los datos e intentalo de nuevo";
        #endregion

        #region Propiedades
        private CurrentUser currentUser;
        private UserDAO userDAO;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;
        #endregion

        #region Constructores
        public VM_Login()
        {
            userDAO = new UserDAO();
            currentUser = CurrentUser.GetInstance();
        }
        #endregion

        #region Commands
        /// <summary>
        /// Este metodo valida los datos e intenta iniciar sesión. Si lo consigue navega a la pagina Home
        /// </summary>
        [RelayCommand]
        async void Login()
        {
            try
            {
                //Comprobamos que los campos no estén vacios
                if (!Email.IsNullOrEmpty() && !Password.IsNullOrEmpty())
                {
                    //Obtenemos el usuario con ese email y password
                    ClsUser user = userDAO.GetUserByEmailAndPassword(Email, Password);

                    if (user != null)
                    {
                        //Actualizamos el usuario actual
                        currentUser.User = user;
                        Navigate("//HomePage");
                    }
                    else
                    {
                        ShowErrorMessage(LOGIN_ERROR);
                    }
                }
                else
                {
                    ShowErrorMessage(EMPTY_FIELDS);
                }
            }
            catch (Exception)
            {
                ShowErrorMessage(GENERIC_ERROR);
            }
        }


        /// <summary>
        /// Este método navega hacia la pagina CreateAccount
        /// </summary>
        [RelayCommand]
        async void CreateAccount()
        {
            Navigate($"//{nameof(CreateAccountPage)}");
        }
        #endregion

    }
}
