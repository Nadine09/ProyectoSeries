namespace SeriesApp_UI.Models
{
    /// <summary>
    /// Esta clase contendrá las temporadas que tiene una serie y el número total de episodios por temporada
    /// </summary>
    public class ClsSeriesWithEpisodesPerSeason : ClsSeries
    {
        #region Propiedades
        public List<ClsSeasonNumberWithMaxEpisode> Episodes { get; set; }
        #endregion

        #region Constructores
        public ClsSeriesWithEpisodesPerSeason(long id, string name, string synopsis, int state, DateTime launchDate, int mra, double valuation, string imageUrl, List<ClsSeasonNumberWithMaxEpisode> episodes) : base(id, name, synopsis, state, launchDate, mra, valuation, imageUrl)
        {
            this.Episodes = episodes;
        }
        public ClsSeriesWithEpisodesPerSeason(ClsSeries clsSeries, List<ClsSeasonNumberWithMaxEpisode> episodes) : base(clsSeries)
        {
            this.Episodes = episodes;
        }
        #endregion
    }
}
