using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TheGarden.BL;

namespace TheGarden.DL
{
    public class SqlRepository : IRepository
    {
        // Fields
        private readonly string _connectionString;
        private readonly ILogger<SqlRepository> _logger;

        // Constructor
        public SqlRepository( string connectionString, ILogger<SqlRepository> logger )
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        public async Task EnterNewPlantAsync(Plant newPlant)
        {
            using SqlConnection connection = new SqlConnection(this._connectionString);

            string cmdText = "INSERT INTO [Garden].[Plants] (SName, CName, Zone, Size, AdoptionDate) VALUES (@sname, @cname, @zone, @size, @adate);";

            await connection.OpenAsync();

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@sname", newPlant.ScientificName);
            cmd.Parameters.AddWithValue("@cname", newPlant.CommonName);
            cmd.Parameters.AddWithValue("@zone", newPlant.Zone);
            cmd.Parameters.AddWithValue("@size", newPlant.Size);
            cmd.Parameters.AddWithValue("@adate", newPlant.AdoptionDate);

            await cmd.ExecuteNonQueryAsync();
            await connection.CloseAsync();

            _logger.LogInformation("Executed EnterNewPlantAsync");
        }

        public async Task<IEnumerable<Plant>> GetAllPlantsAsync()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            await connection.OpenAsync();

            string cmdText = "SELECT * FROM [Garden].[Plants];";

            using SqlCommand cmd = new SqlCommand( cmdText, connection);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            List<Plant> plants = new List<Plant>();

            while (await reader.ReadAsync()) 
            {
                int pId = (int)reader["PlantID"];
                string sName = reader["SName"].ToString() ?? "";
                string cName = reader["CName"].ToString() ?? "";
                int zone = (int)reader["Zone"];
                Size size = (Size)reader["Size"];
                DateTime adate = (DateTime)reader["AdoptionDate"];

                plants.Add(new Plant(pId, sName, cName, zone, size, adate));
            }

            await connection.CloseAsync();
            _logger.LogInformation("Executed GetAllPlantsAsync. {0} plants returned.", plants.Count);

            return plants;
        }

        public async Task<Plant> GetPlantByIdAsync(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            await connection.OpenAsync();

            string cmdText = "SELECT * FROM [Garden].[Plants] WHERE PlantID = @id;";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@id", id);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            Plant newLeafyBoi = new Plant();

            await reader.ReadAsync();

            newLeafyBoi.PlantID = (int)reader["PlantID"];
            newLeafyBoi.ScientificName = reader["SName"].ToString() ?? "";
            newLeafyBoi.CommonName = reader["CName"].ToString() ?? "";
            newLeafyBoi.Zone = (int)reader["Zone"];
            newLeafyBoi.Size = (Size)reader["Size"];
            newLeafyBoi.AdoptionDate = (DateTime)reader["AdoptionDate"];

            await connection.CloseAsync();
            _logger.LogInformation("Executed GetPlantByIdAsync.");
            return newLeafyBoi;
        }

        public async Task DeletePlantByIdAsync(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);

            await connection.OpenAsync();

            string cmdText = "DELETE FROM [Garden].[Plants] WHERE PlantID = @id;";

            using SqlCommand cmd = new SqlCommand(cmdText, connection);

            cmd.Parameters.AddWithValue("@id", id);

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            await connection.CloseAsync();
            _logger.LogInformation($"Executed DeletePlantByIdAsnyc and deleted the plant id: {id}.");
        }
    }
}
