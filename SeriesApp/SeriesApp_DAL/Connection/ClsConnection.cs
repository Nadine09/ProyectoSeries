using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_DAL.Connection
{
    public class ClsConnection
    {
        //TODO Write values
        private const String Server = "DESKTOP-2JDHKTU\\SQLEXPRESS";
        private const String Database = "PruebaSeries";
        private const String User = "prueba";
        private const String Password = "prueba";

        public string ConnectionString { get; set; }

        public ClsConnection()
        {
            //TODO Write connection string
            ConnectionString = "";
        }

        
        //public SqlConnection getConnection()
        //{
        //    SqlConnection sqlConnection = null;
        //    try
        //    {
        //        sqlConnection = new SqlConnection(ConnectionString);
        //    }catch (Exception e)
        //    {


        //    }
        //    return sqlConnection;
        //}
    }
}
