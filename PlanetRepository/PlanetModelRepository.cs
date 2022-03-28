using PlanetRepository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanetRepositoryCommon;
using PlanetModel;

namespace PlanetRepository
{
    public class PlanetModelRepository : IPlanetModelRepository
    {
        static string connectionString = @"Data Source=ST-01\MSSQLSERVER01;Initial Catalog=Space;Integrated Security=True";
        public List<Planet> GetAll()
        {
            List<Planet> planetlist = new List<Planet>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Planet;", connection);

                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

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

                    dataReader.Close();
                    connection.Close();
                }
            }
            return planetlist;
        }
    }
}