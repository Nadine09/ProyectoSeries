using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace SeriesApp_UI.ViewModels
{
    public partial class VM_Login : ObservableObject
    {

        private UserDAO userDAO;

        public const string LOGIN_ERROR = "No se ha podido hacer login, revisa los datos e intentalo de nuevo";

        [ObservableProperty]
        ObservableCollection<ClsUser> users;

        [ObservableProperty]
        ClsUser selectedUser;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string errorMessage;

        public VM_Login()
        {
            userDAO = new UserDAO();
            users = new ObservableCollection<ClsUser>(userDAO.GetAll()); //QUITAR
        }



        #region Commands
        [RelayCommand]
        async void Login()
        {
            errorMessage = "";
            //ClsUser user = userDAO.GetUserByEmailAndPassword(email, password); //TODO Mostrar
            ClsUser user = SelectedUser; //Quitar
            if (user != null)
            {
                App.Current.Restart();
                App.Current.User = user;
                await SecureStorage.Default.SetAsync("Account", user.Id.ToString()); //QUITAR
                await Shell.Current.GoToAsync("//HomePage");
                //await Shell.Current.GoToAsync($"//{nameof(HomePage)}?", new Dictionary<string, object>
                //{
                //    ["UserId"] = user
                //});

                //var dictionary = new Dictionary<string, object>();
                //dictionary.Add("User", user);
                //await Shell.Current.GoToAsync("/HomePage", dictionary);
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
        async Task GetUserAsync() //QUITAR
        {
            Id = long.Parse(await SecureStorage.Default.GetAsync("Account"));
        }

    }
}
