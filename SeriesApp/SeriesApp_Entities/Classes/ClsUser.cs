﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_Entities.Classes
{
    public class ClsUser
    {
        #region Public properties
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        #endregion

        #region Constructors 
        public ClsUser()
        {
        }

        public ClsUser(int id, string userName, string email, string password)
        {
            Id = id;
            UserName = userName;
            Email = email;
        }
        #endregion

    }
}
