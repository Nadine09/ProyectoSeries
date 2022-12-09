using Microsoft.Data.SqlClient;
using SeriesApp_Entities.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_DAL.DAO
{
    public class SeasonDAO : GenericDAO<ClsSeason>
    {

        #region Constants
        public const string GET_SEASONS_BY_SERIES = "";
        #endregion

        public int GetSeasonsNumberBySeriesId(int idSeries)
        {
            return executeQueryGetInt(GET_SEASONS_BY_SERIES);
        }

        public override ClsSeason BuildObject(SqlDataReader sqlDataReader)
        {
            throw new NotImplementedException();
        }

        
    }


}
