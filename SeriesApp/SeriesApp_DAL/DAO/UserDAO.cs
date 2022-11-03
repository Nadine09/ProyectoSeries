using Microsoft.Data.SqlClient;
using Microsoft.Maui.ApplicationModel.Communication;
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
        public const string TABLE_NAME = "NAD_Users";
        public const string INSERT = $"INSERT INTO {TABLE_NAME} (UserName, Email, Password) VALUES ('@username', '@email', '@password')";
        public const string UPDATE = $"UPDATE {TABLE_NAME} SET UserName = @username, Password '@password'";
        public const string VALIDATE_USER = $"SELECT id, username, email, [password] FROM {TABLE_NAME} WHERE Email = '@email' AND Password = '@password'";

        

        public ClsUser GetUserByEmailAndPassword(string email, string password)
        {
            ClsUser user = null;
            List<ClsUser> userList = Select(VALIDATE_USER.Replace("@email", email).Replace("@password", password));
            if (userList != null && userList.Count > 0)
            {
                user = userList[0];
            }
            return user;
        }

        public ClsUser CreateUser(ClsUser user)
        {
            string commmand = INSERT.Replace("@username", user.UserName).Replace("@email", user.Email).Replace("@password", user.Password);

            user.Id = InsertOneGetId(commmand);

            return user;
        }

        public override ClsUser BuildObject(SqlDataReader sqlDataReader)
        {
            ClsUser user = new ClsUser
            {
                Id = (int)sqlDataReader["id"],
                UserName = (string)sqlDataReader["username"],
                Email = (string)sqlDataReader["email"],
                Password = (string)sqlDataReader["password"]
            };

            return user;
        }
    }
}
