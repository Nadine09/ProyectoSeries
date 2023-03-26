﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesApp_Entities.Classes
{
    public class ClsEpisode
    {        
        #region Propiedades
        public long Id { get; set; }
        public int Orden { get; set; }
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public DateTime LaunchDate { get; set; }
        public string ImageUrl { get; set; }
        public long SeasonId { get; set; }
        #endregion

        #region Constructores
        public ClsEpisode()
        {
        }

        public ClsEpisode(long id, int orden, string name, string synopsis, DateTime launchDate, string imageUrl, long seasonId)
        {
            Id = id;
            Orden = orden;
            Name = name;
            Synopsis = synopsis;
            LaunchDate = launchDate;
            ImageUrl = imageUrl;
            SeasonId = seasonId;
        }
        #endregion
    }
}
