using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace ABC_RetailApp.Services
{
    public class DatabaseService
    {
        private readonly string _conn;

        public DatabaseService(IConfiguration config)
        {
            _conn = config.GetConnectionString("AzureSQL");
        }

        public List<string> GetCustomers()
        {
            var customers = new List<string>();

            using (SqlConnection conn = new SqlConnection(_conn))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Name FROM Customers", conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(reader.GetString(0));
                    }
                }
            }

            return customers;
        }
    }
}

