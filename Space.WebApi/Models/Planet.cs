using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Space.WebApi.Models
{
    public class RESTPlanet
    {

        public int PlanetID { get; set; }
        public string PlanetName { get; set; }
        public string PlanetLocation { get; set; }

        public RESTPlanet()
        {

        }
    }
}