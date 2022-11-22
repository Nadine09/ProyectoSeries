using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_Entities.Classes
{
    public class ClsSeason
    {        
        #region Public properties
        public long Id { get; set; }
        public int Orden { get; set; }
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public int State { get; set; }
        public DateTime LaunchDate { get; set; }
        public string ImageUrl { get; set; }
        public long SerieId { get; set; }
        #endregion

        #region Constructors
        public ClsSeason()
        {
        }

        public ClsSeason(long id, int orden, string name, string synopsis, int state, DateTime launchDate, string imageUrl, long serieId)
        {
            Id = id;
            Orden = orden;
            Name = name;
            Synopsis = synopsis;
            State = state;
            LaunchDate = launchDate;
            ImageUrl = imageUrl;
            SerieId = serieId;
        }
        #endregion
    }
}
