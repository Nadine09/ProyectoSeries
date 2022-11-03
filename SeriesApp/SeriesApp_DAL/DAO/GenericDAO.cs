using Microsoft.Data.SqlClient;
using Microsoft.Maui.Controls;
using SeriesApp_DAL.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_DAL.DAO
{
    public abstract class GenericDAO<T> : IGenericDAO<T>
    {
        #region Constants
        public const string GET_ID = "; SELECT SCOPE_IDENTITY()";
        #endregion


        #region Properties
        protected ConnectionProvider connectionProvider;

        #endregion

        #region Constructors
        public GenericDAO()
        {
            connectionProvider = new ConnectionProvider();
        }

        #endregion

        public List<T> Select(string command)
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
        /// Este método inserta un objeto en la base de datos y devuelve el id del objeto insertado.
        /// </summary>
        /// <param name="command">Instrucción SQL para insertar el objeto</param>
        /// <returns></returns>
        public int InsertOneGetId(string command)
        {
            int id = 0;

            //Creamos y abrimos la conexión
            SqlConnection sqlConnection = connectionProvider.getConnection();

            //Creamos un SqlCommand con el comando apropiado y la conexion
            SqlCommand sqlCommand = new SqlCommand(command + GET_ID, sqlConnection);

            //Obtenemos el SqlDataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //Miramos si hay alguna fila
            if (sqlDataReader.HasRows)
            {
                //Nos movemos hasta la fila y la leemos
                sqlDataReader.Read();
                id = (int)sqlDataReader[0];                
            }

            //Cerramos el SqlDataReader
            sqlDataReader.Close();

            //Cerramos la conexión
            connectionProvider.closeConnection(sqlConnection);

            return id;
        }

        public void Insert(T item)
        {
            
        }

        public void Update(T item)
        {
            
        }
        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public abstract T BuildObject(SqlDataReader sqlDataReader);

        //public T findById(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
