using Microsoft.Data.SqlClient;
using SeriesApp_DAL.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_DAL.DAO
{
    public abstract class GenericAbstractDAO
    {
        protected ConnectionProvider connectionProvider;

        protected GenericAbstractDAO()
        {
            connectionProvider = new ConnectionProvider();
        }

        /// <summary>
        /// Este método ejecutará la instruccion pasada por parámetros
        /// </summary>
        /// <param name="command">Instrucción que se ejecutará</param>
        protected void ExecuteNonQuery(string command)
        {
            //Creamos y abrimos la conexión
            SqlConnection sqlConnection = connectionProvider.getConnection();

            //Creamos un SqlCommand con el comando apropiado y la conexion
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);

            //Ejecutamos
            sqlCommand.ExecuteNonQuery();

            //Cerramos la conexión
            connectionProvider.closeConnection(sqlConnection);
        }
    }
}
