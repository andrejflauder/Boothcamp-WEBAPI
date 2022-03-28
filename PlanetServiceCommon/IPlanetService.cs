using PlanetModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetServiceCommon
{
    public class IPlanetService : IPlanetServiceBase
    {
        Planet GetById(int PlanetID);
    }
}
