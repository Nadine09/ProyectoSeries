using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_Entities.Classes
{
    public class ClsUser
    {
        #region Propiedades
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        #endregion

        #region Constructores 
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
