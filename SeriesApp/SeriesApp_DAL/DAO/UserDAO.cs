using SeriesApp_Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_DAL.DAO
{
    public class UserDAO : GenericDAO<ClsUser>
    {
        public const string TABLE_NAME = "Users";
        public const string INSERT = $"INSERT INTO {TABLE_NAME} (UserName, Email, Password) VALUES ('@username', '@email', '@password')";
        public const string UPDATE = $"UPDATE {TABLE_NAME} SET UserName = @username, Password '@password'";
        public const string VALIDATE_USER = $"SELECT id FROM {TABLE_NAME} WHERE Email = @mail AND Password = @password";


    }
}
