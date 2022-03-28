using PlanetModel;
using PlanetRepository;
using PlanetRepositoryCommon;
using PlanetServiceCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetService
{
    public class PlanetService : IPlanetService
    {
        public List<Planet> GetAll()
        {
            IPlanetModelRepository planetModelRepository = new IPlanetModelRepository();
            List<Planet> planetlist = Planet.GetAll();
            return planetlist;
        }

        public Planet GetById(int Id)
        {
            IPlanetModelRepository planetModelRepository = new IPlanetModelRepository();
            Planet planetlist = planetModelRepository.GetById(Id);
            return planetlist;
        }
    }
}
