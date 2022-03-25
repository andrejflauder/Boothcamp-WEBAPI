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

        public HttpResponseMessage GET()
        {
            List<Planet> planetlist = new List<Planet>();
            

                string connectionString = @"Data Source=ST-01\MSSQLSERVER01;Initial Catalog=Space;Integrated Security=True";
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
    }
}
