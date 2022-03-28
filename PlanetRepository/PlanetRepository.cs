using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Space.Repository.Common;
using Space.Model;


namespace Space.Repository
{
    public class PlanetRepository : IPlanetModelRepository
    {
        static string connectionString = @"Data Source=ST-01\MSSQLSERVER01;Initial Catalog=Space;Integrated Security=True";
        public async Task<List<Planet>> GetPlanet()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            List<Planet> planetlist = new List<Planet>();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Planet;", connection);

                await connection.OpenAsync();

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