using Space.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Model
{
    public class Planet : IPlanet
    {
        public int PlanetID { get; set; }
        public string PlanetName { get; set; }
        public string PlanetLocation { get; set; }


        public Planet()
        {

        }
    }
}
