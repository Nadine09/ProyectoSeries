namespace SeriesApp_DAL.DAO
{
    public abstract class GenericAbstractDAO
    {
        #region Properties
        protected ConnectionProvider connectionProvider;
        #endregion

        #region Constructors
        protected GenericAbstractDAO()
        {
            connectionProvider = new ConnectionProvider();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Este método inicializa todo lo necesario para realizar una consulta. Crea y abre una conexión y la asigna a sqlConnection.
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlCommand"></param>
        /// <param name="sqlDataReader"></param>
        /// <param name="command"></param>
        protected void StartQuery(ref SqlConnection sqlConnection, ref SqlCommand sqlCommand, ref SqlDataReader sqlDataReader, string command)
        {
            //Creamos y abrimos la conexión
            sqlConnection = connectionProvider.getConnection();

            //Creamos un SqlCommand con el comando apropiado y la conexion
            sqlCommand = new SqlCommand(command, sqlConnection);

            //Obtenemos el SqlDataReader
            sqlDataReader = sqlCommand.ExecuteReader();
        }

        /// <summary>
        /// Este método cierra la SqlConnection y el SqlDataReader pasados por parámetros
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sqlDataReader"></param>
        protected void CloseAll(ref SqlConnection sqlConnection, ref SqlDataReader sqlDataReader)
        {
            //Cerramos el SqlDataReader
            sqlDataReader.Close();

            //Cerramos la conexión
            connectionProvider.closeConnection(sqlConnection);
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
        #endregion
    }
}
