using Microsoft.Data.SqlClient;

namespace Leteo_DAL.DAO
{
    public class UserDAO : GenericDAO<ClsUser>
    {
        public const string TABLE_NAME = "NAD_Users";
        public const string INSERT = $"INSERT INTO {TABLE_NAME} (UserName, Email, Password) VALUES ('@username', '@email', '@password')";
        public const string UPDATE = $"UPDATE {TABLE_NAME} SET UserName = @username, Password '@password'";
        public const string SELECT_USER_BY_EMAIL_AND_PASSWORD = $"SELECT id, username, email, [password] FROM {TABLE_NAME} WHERE Email = '@email' AND Password = '@password'";
        
        public const string SELECT_BY_ID = $"SELECT id, username, email, [password] FROM {TABLE_NAME} WHERE Id = '@id'";

        public UserDAO()
        {
            cmdSelectById = SELECT_BY_ID;
        }

        public ClsUser GetUserByEmailAndPassword(string email, string password)
        {      
            return ExecuteQueryOneObject(SELECT_USER_BY_EMAIL_AND_PASSWORD.Replace("@email", email).Replace("@password", password));            
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
