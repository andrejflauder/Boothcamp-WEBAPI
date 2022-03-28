using Space.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Space.WebApi.Controllers
{

    public class PlanetController : ApiController
    {
    
        [Route("api/planet/")]
        [HttpGet]

        public HttpResponseMessage GetPlanets()
        {
            List<Planet> planetlist = new List<Planet>();
            

                string connectionString = @"Data Source=DESKTOP-N36U6FI;Initial Catalog=Space;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Planet";
                    SqlCommand command = new SqlCommand(sql, connection);

                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Planet planet = new Planet();

                            planet.PlanetID = Convert.ToInt32(dataReader["PlanetID"]);
                            planet.PlanetName = Convert.ToString(dataReader["PlanetName"]);
                            planet.PlanetLocation = Convert.ToString(dataReader["PlanetLocation"]);

                            planetlist.Add(planet);
                        }
                    }

                    connection.Close();
                }

                return Request.CreateResponse(HttpStatusCode.OK,planetlist);
            
        }

        [Route("api/planet/{Id}")]
        [HttpGet]

        public HttpResponseMessage GetPlanetById(int Id)
        {
            string connectionString = @"Data Source=DESKTOP-N36U6FI;Initial Catalog=Space;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Planet";
                SqlCommand command = new SqlCommand(sql, connection);

                SqlDataReader dataReader = command.ExecuteReader();
                List<Planet> planetlist = new List<Planet>();

                Planet GetPlanet()
                {

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            Planet planet = new Planet();
                            planet.PlanetID = dataReader.GetInt32(0);
                            planet.PlanetName = dataReader.GetString(1);
                            planet.PlanetLocation = dataReader.GetString(2);

                            planetlist.Add(planet);
                        }
                        Planet searchedPlanet = planetlist.Where(x => x.PlanetID == Id).Select(x => x).FirstOrDefault();
                        return searchedPlanet;
                    }
                    else
                    {
                        return null;
                    }
                }
                Planet PlanetId = GetPlanet();
                if (PlanetId != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, PlanetId);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "There is no planet with that ID");
                }
            }
        }

        

    }
}
