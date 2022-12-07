namespace Leteo_Entities
{
    public class ClsGenre
    {
        #region Public properties
        public long Id { get; set; }
        public string Name { get; set; }
        #endregion

        #region Constructors 
        public ClsGenre()
        {
        }

        public ClsGenre(long id, string name)
        {
            Id = id;
            Name = name;
        }
        #endregion
    }
}
