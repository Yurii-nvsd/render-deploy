using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace PetStoreService.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            string sql = File.ReadAllText("Data/SeedData.sql");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}