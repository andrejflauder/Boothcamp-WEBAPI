using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space.Model.Common
{
    public interface IPlanet
    {
        int PlanetID { get; set; }
        string PlanetName { get; set; }
        string PlanetLocation { get; set; }
    }
}
