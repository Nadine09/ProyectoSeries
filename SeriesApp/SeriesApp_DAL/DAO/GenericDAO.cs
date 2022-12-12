using Microsoft.Data.SqlClient;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
using SeriesApp_DAL.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_DAL.DAO
{
    public abstract class GenericDAO<T> : GenericAbstractDAO
    {        

        #region Properties
        public string cmdSelectAll;
        public string cmdSelectById;
        #endregion

        #region Constructors
        public GenericDAO() : base()
        {

        }

        protected GenericDAO(string cmdSelectAll, string cmdSelectById) : base()
        {
            this.cmdSelectAll = cmdSelectAll;
            this.cmdSelectById = cmdSelectById;
        }
        #endregion

        /// <summary>
        /// Este método usa la propiedad cmdSelectAll, ejecuta la consulta y devuelve la lista de objetos T
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            return ExecuteQuery(cmdSelectAll);
        }

        /// <summary>
        /// Este método usa la propiedad cmdSelectById, reemplaza @id en la cadena por el id dado y ejecuta la consulta. Devuelve un único objeto T
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(long id)
        {
            return ExecuteQueryOneObject(cmdSelectById.Replace("@id", id.ToString()));
        }

        /// <summary>
        /// Este método ejecuta una consulta que devuelve un único objeto T. La consulta será el string command pasado por parámetros.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public T ExecuteQueryOneObject(string command)
        {
            T item = default;

            //Creamos y abrimos la conexión
            SqlConnection sqlConnection = connectionProvider.getConnection();

            //Creamos un SqlCommand con el comando apropiado y la conexion
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);

            //Obtenemos el SqlDataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //Miramos si hay alguna fila
            if (sqlDataReader.HasRows)
            {
                //Nos movemos hasta la fila y la leemos
                if (sqlDataReader.Read())
                {
                    //Construimos el objeto y lo añadimos a la lista
                    item = BuildObject(sqlDataReader);
                }

            }

            //Cerramos el SqlDataReader
            sqlDataReader.Close();

            //Cerramos la conexión
            connectionProvider.closeConnection(sqlConnection);

            //Devolvemos la lista de objetos
            return item;
        }

        /// <summary>
        /// Este método ejecuta una consulta que devuelve una lista de objetos T. La consulta será el string command pasado por parámetros.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public List<T> ExecuteQuery(string command)
        {
            List<T> items = null;

            //Creamos y abrimos la conexión
            SqlConnection sqlConnection = connectionProvider.getConnection();

            //Creamos un SqlCommand con el comando apropiado y la conexion
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);

            //Obtenemos el SqlDataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //Miramos si hay alguna fila
            if (sqlDataReader.HasRows)
            {
                items = new List<T>();

                //Mientras siga teniendo filas nos movemos hasta la fila y la leemos
                while (sqlDataReader.Read())
                {
                    //Construimos el objeto y lo añadimos a la lista
                    items.Add(BuildObject(sqlDataReader));
                }
            }

            //Cerramos el SqlDataReader
            sqlDataReader.Close();

            //Cerramos la conexión
            connectionProvider.closeConnection(sqlConnection);

            //Devolvemos la lista de objetos
            return items;
        }

        /// <summary>
        /// Este método ejecuta una consulta que devuelve un único valor int. La consulta será el string command pasado por parámetros.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public int executeQueryGetInt(string command)
        {
            int number = 0;

            //Creamos y abrimos la conexión
            SqlConnection sqlConnection = connectionProvider.getConnection();

            //Creamos un SqlCommand con el comando apropiado y la conexion
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);

            //Obtenemos el SqlDataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //Miramos si hay alguna fila
            if (sqlDataReader.HasRows)
            {
                //Nos movemos hasta la fila y la leemos
                sqlDataReader.Read();
                number = (int)sqlDataReader[0];
            }

            //Cerramos el SqlDataReader
            sqlDataReader.Close();

            //Cerramos la conexión
            connectionProvider.closeConnection(sqlConnection);

            return number;
        }

        /// <summary>
        /// Este método crea un objeto con los valores del sqlReader.
        /// </summary>
        /// <param name="sqlDataReader">Objeto SqlDataReader en el que se buscarán los valores para crear el objeto</param>
        /// <returns>Objeto creado</returns>
        public abstract T BuildObject(SqlDataReader sqlDataReader);
    }
}
