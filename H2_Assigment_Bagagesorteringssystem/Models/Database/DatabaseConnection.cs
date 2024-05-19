using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models.Database
{
    internal class DatabaseConnection
    {
        private readonly string filePath = @"C:\connection.txt";
        private string connectionString;

        internal DatabaseConnection()
        {
            LoadConnectionString();
        }

        private void LoadConnectionString()
        {
            try
            {
                connectionString = File.ReadAllText(filePath).Trim();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading the connection string from the file: {ex.Message}");
            }
        }

        internal MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
