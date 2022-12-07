namespace Leteo_Entities
{
    public class ClsSeries
    {
        #region Public properties
        public long Id { get; set; }
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public int State { get; set; }
        public DateTime LaunchDate { get; set; }
        public int Mra { get; set; }
        public double Valuation { get; set; }
        public string ImageUrl { get; set; }
        #endregion

        #region Constructors 
        public ClsSeries()
        {
        }

        public ClsSeries(string name, string imageUrl)
        {
            Name = name;
            ImageUrl = imageUrl;
        }

        public ClsSeries(long id, string name, string synopsis, int state, DateTime launchDate, int mra, double valuation, string imageUrl)
        {
            Id = id;
            Name = name;
            Synopsis = synopsis;
            State = state;
            LaunchDate = launchDate;
            Mra = mra;
            Valuation = valuation;
            ImageUrl = imageUrl;
        }

        #endregion

    }
}
