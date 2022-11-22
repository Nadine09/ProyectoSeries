using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_Entities.Classes
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
