namespace SeriesApp_DAL.DAO
{
    public class SeasonDAO : GenericDAO<ClsSeason>
    {
        #region Constantes
        public const string GET_SEASONS_BY_SERIES = "";
        #endregion

        #region Métodos
        public int GetSeasonsNumberBySeriesId(int idSeries)
        {
            return executeQueryGetInt(GET_SEASONS_BY_SERIES);
        }
        
        public override ClsSeason BuildObject(SqlDataReader sqlDataReader)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
