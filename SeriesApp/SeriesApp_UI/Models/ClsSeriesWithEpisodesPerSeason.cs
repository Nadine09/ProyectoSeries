namespace SeriesApp_UI.Models
{
    public class ClsSeriesWithEpisodesPerSeason : ClsSeries
    {
        public List<ClsSeasonNumberWithMaxEpisode> Episodes { get; set; }

        public ClsSeriesWithEpisodesPerSeason(long id, string name, string synopsis, int state, DateTime launchDate, int mra, double valuation, string imageUrl, List<ClsSeasonNumberWithMaxEpisode> episodes) : base(id, name, synopsis, state, launchDate, mra, valuation, imageUrl)
        {
            this.Episodes = episodes;
        }
        public ClsSeriesWithEpisodesPerSeason(ClsSeries clsSeries, List<ClsSeasonNumberWithMaxEpisode> episodes) : base(clsSeries)
        {
            this.Episodes = episodes;
        }
    }
}
