﻿using CommunityToolkit.Mvvm.ComponentModel;
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
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
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



    }
}
