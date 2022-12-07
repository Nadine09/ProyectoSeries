﻿namespace Leteo_Entities
{
    public class ClsUser
    {
        #region Public properties
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        #endregion

        #region Constructors 
        public ClsUser()
        {
        }

        public ClsUser(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }

        public ClsUser(int id, string userName, string email, string password)
        {
            Id = id;
            UserName = userName;
            Email = email;
            Password = password;
        }
        #endregion

        
    }
}
