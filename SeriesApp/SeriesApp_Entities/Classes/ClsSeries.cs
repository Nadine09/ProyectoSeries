using SeriesApp_Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_Entities.Classes
{
    public class ClsSeries
    {


        #region Public properties
        public long Id { get; set; }
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public string State { get; set; }
        public int Year { get; set; }
        public MRA Mra { get; set; }
        #endregion

        #region Constructors 
        public ClsSeries()
        {
        }

        public ClsSeries(long id, string name, string synopsis, string state, int year, MRA mra)
        {
            Id = id;
            Name = name;
            Synopsis = synopsis;
            State = state;
            Year = year;
            Mra = mra;
        }
        #endregion

    }
}
