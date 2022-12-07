using Microsoft.Data.SqlClient;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leteo_DAL.Connection
{
    public class ConnectionProvider
    {
        
        private const String Server = "iesnervion.database.windows.net";
        private const String Database = "WPFSample";
        private const String User = "prueba";
        private const String Password = "iesnervion123.";
        private const String ConnectionString = $"Server=tcp:{Server},1433;Initial Catalog={Database};Persist Security Info=False;User ID={User};Password={Password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        #region Metodos
        /// <summary>
        /// Método que crea y devuelve una conexión con la base de datos
        /// </summary>
        /// <returns>Una conexión abierta con la base de datos</returns>
        public SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection();

            try
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();
            }
            catch (SqlException)
            {
                throw;
            }

            return connection;

        }

        /// <summary>
        /// Método que abre la conexion pasada por parámetros
        /// Precondiciones: La conexión no debe ser nula
        /// </summary>
        /// <param name="connection"></param>
        public void openConnection(SqlConnection connection)
        {
            connection.Open();
        }

        /// <summary>
        /// Este metodo cierra una conexión con la Base de datos
        /// </summary>
        /// <post>La conexion es cerrada</post>
        /// <param name="connection">SqlConnection pr referencia. Conexion a cerrar
        /// </param>
        public void closeConnection(SqlConnection connection)
        {
            try
            {
                connection.Close();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion



    }
}
