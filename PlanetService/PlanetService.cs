using Space.Model;
using Space.Repository.Common;
using Space.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Space.Repository;
using Space.Common;

namespace Space.Service
{
    public class PlanetService : IPlanetService
    {
        public async Task<List<Planet>> GetPlanet(PlanetRepository planetRepository)
        {
            PlanetRepository planetModelRepository = new PlanetRepository();
            List<Planet> planetlist = await planetRepository.GetPlanet();
            return planetlist;
        }
    }

}
