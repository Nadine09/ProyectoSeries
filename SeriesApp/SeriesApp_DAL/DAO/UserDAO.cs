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
        #region Constantes
        public const string TABLE_NAME = "NAD_Users";
        public const string VALIDATE_EMAIL = "SELECT * FROM NAD_Users WHERE email = '@email'";
        public const string INSERT = $"INSERT INTO {TABLE_NAME} (UserName, Email, Password) VALUES ('@username', '@email', '@password')";
        public const string UPDATE = $"UPDATE {TABLE_NAME} SET UserName = @username, Password '@password'";
        public const string SELECT_USER_BY_EMAIL_AND_PASSWORD = $"SELECT id, username, email, [password] FROM {TABLE_NAME} WHERE Email = '@email' AND Password = '@password'";
        
        public const string SELECT_BY_ID = $"SELECT id, username, email, [password] FROM {TABLE_NAME} WHERE Id = '@id'";
        public const string SELECT_ALL = $"SELECT id, username, email, [password] FROM {TABLE_NAME}";
        #endregion

        #region Constructores
        public UserDAO()
        {
            cmdSelectById = SELECT_BY_ID;
            cmdSelectAll = SELECT_ALL;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Valida el email dado. Si el email ya está en uso devolverá FALSE, en caso contrario, TRUE.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ValidateEmail(string email)
        {
            bool valid = true;
            SqlConnection sqlConnection = null;
            SqlCommand sqlCommand = null;
            SqlDataReader sqlDataReader = null;

            StartQuery(ref sqlConnection, ref sqlCommand, ref sqlDataReader, VALIDATE_EMAIL.Replace("@email", email));

            if (sqlDataReader.HasRows)
            { 
                valid = false;
            }

            CloseAll(ref sqlConnection, ref sqlDataReader);

            return valid;
        }

        /// <summary>
        /// Obtiene (si existe) el usuario por su email y constraseña
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ClsUser GetUserByEmailAndPassword(string email, string password)
        {      
            return ExecuteQueryOneObject(SELECT_USER_BY_EMAIL_AND_PASSWORD.Replace("@email", email).Replace("@password", password));            
        }

        /// <summary>
        /// Este método inserta un usuario en la base de datos y devuelve el usuario insertado 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ClsUser CreateUser(ClsUser user)
        {
            string command = INSERT.Replace("@username", user.UserName).Replace("@email", user.Email).Replace("@password", user.Password);
            ExecuteNonQuery(command);
            return GetUserByEmailAndPassword(user.Email, user.Password);
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
        #endregion
    }
}
