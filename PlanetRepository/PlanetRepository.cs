using PlanetRepository.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetRepository
{
    public class PlanetRepository
    {

        public List<Planet> Get()
        {

            List<Planet> planetlist = new List<Planet>();

            string connectionString = @"Data Source=ST-01\MSSQLSERVER01;Initial Catalog=Space;Integrated Security=True";
            using (var connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Planet";
                var command = new System.Data.SqlClient.SqlCommand(sql, connection);

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
            return planetlist;
        }
    }
}