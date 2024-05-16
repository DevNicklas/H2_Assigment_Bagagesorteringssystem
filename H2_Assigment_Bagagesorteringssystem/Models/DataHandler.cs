using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    internal class DataHandler
    {
        public static void DatahandlerTest()
        {
            string connectionString = "Server=localhost;Database=airport_schedule;User ID=root;Password=;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Successfully connected to the database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: Unable to connect to the database. {ex.Message}");
                }
            }
        }
    }
}
