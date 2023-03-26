using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LeteoApp_UI.Classes;
using Microsoft.IdentityModel.Tokens;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_CreateAccount : VM_Base
    {
        #region Constantes
        public const string CREATE_ACCOUNT_ERROR = "No se ha podido crear el usuario";
        public const string INVALID_EMAIL = "El email ya está en uso, prueba con otro o inicia sesión";
        public const string CREATE_ACCOUNT_EMPTY_FIELDS = "Los campos no pueden estar vacíos";
        #endregion

        #region Propiedades
        private CurrentUser currentUser;

        [ObservableProperty]
        string username;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        private UserDAO userDAO;
        #endregion

        #region Constructores
        public VM_CreateAccount()
        {
            userDAO = new UserDAO();
            currentUser = CurrentUser.GetInstance();
        }
        #endregion

        #region Commands
        /// <summary>
        /// Este método valida los datos de registro (Username, Email y Password) y si son válidos intenta crear un usuario.
        /// Si se consigue se navegará a Home.
        /// </summary>        
        [RelayCommand]
        async void CreateAccount()
        {
            try
            {

                if (!Username.IsNullOrEmpty() && !Email.IsNullOrEmpty() && !Password.IsNullOrEmpty())
                {
                    if (userDAO.ValidateEmail(Email))
                    {

                        //Intentamos crear el nuevo usuario
                        ClsUser newUser = new ClsUser(Username, Email, Password);
                        newUser = userDAO.CreateUser(newUser);

                        if (newUser != null && newUser.Id != 0)
                        {
                            //Actualizamos el usuario actual
                            currentUser.User = newUser;

                            Navigate("//HomePage");
                        }
                        else
                        {
                            ShowErrorMessage(CREATE_ACCOUNT_ERROR);
                        }
                    }
                    else
                    {
                        ShowErrorMessage(INVALID_EMAIL);
                    }
                }
                else
                {
                    ShowErrorMessage(CREATE_ACCOUNT_EMPTY_FIELDS);
                }
            }
            catch (Exception)
            {
                ShowErrorMessage(GENERIC_ERROR);
            }
        }

        /// <summary>
        /// Este metodo navega a la pagina Login
        /// </summary>
        [RelayCommand]
        public async void BackToLogin()
        {
            //Volvemos atrás
            Navigate($"//{nameof(LoginPage)}");
        }
        #endregion
    }
}
