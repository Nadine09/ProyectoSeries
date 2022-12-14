using Leteo_DAL.Connection;
using Microsoft.Data.SqlClient;

namespace Leteo_DAL.DAO
{
    public abstract class GenericDAO<T>
    {
        #region Constants
        public const string GET_ID = "; SELECT SCOPE_IDENTITY()";
        #endregion

        #region Properties
        protected ConnectionProvider connectionProvider;
        
        public string cmdSelectAll;
        public string cmdSelectById;
        #endregion

        #region Constructors
        public GenericDAO()
        {
            connectionProvider = new ConnectionProvider();
        }

        protected GenericDAO(string cmdSelectAll, string cmdSelectById)
        {
            connectionProvider = new ConnectionProvider();
            this.cmdSelectAll = cmdSelectAll;
            this.cmdSelectById = cmdSelectById;
        }
        #endregion

        public List<T> GetAll()
        {
            return ExecuteQuery(cmdSelectAll);
        }

        public T GetById(long id)
        {
            return ExecuteQueryOneObject(cmdSelectById.Replace("@id", id.ToString()));
        }

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
                sqlDataReader.Read();

                //Construimos el objeto y lo añadimos a la lista
                item = BuildObject(sqlDataReader);

            }

            //Cerramos el SqlDataReader
            sqlDataReader.Close();

            //Cerramos la conexión
            connectionProvider.closeConnection(sqlConnection);

            //Devolvemos la lista de objetos
            return item;
        }

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


        /// <summary>
        /// Este método ejecutará la instruccion pasada por parámetros
        /// </summary>
        /// <param name="command">Instrucción que se ejecutará</param>
        public void ExecuteNonQuery(string command)
        {
            //Creamos y abrimos la conexión
            SqlConnection sqlConnection = connectionProvider.getConnection();

            //Creamos un SqlCommand con el comando apropiado y la conexion
            SqlCommand sqlCommand = new SqlCommand(command + GET_ID, sqlConnection);

            //Ejecutamos
            sqlCommand.ExecuteNonQuery();

            //Cerramos la conexión
            connectionProvider.closeConnection(sqlConnection);
        }

        /// <summary>
        /// Este método crea un objeto con los valores del sqlReader.
        /// </summary>
        /// <param name="sqlDataReader">Objeto SqlDataReader en el que se buscarán los valores para crear el objeto</param>
        /// <returns>Objeto creado</returns>
        public abstract T BuildObject(SqlDataReader sqlDataReader);
    }
}
