using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models.Database
{
    /// <summary>
    /// Represents a connection to the MySQL database.
    /// </summary>
    internal class DatabaseConnection
    {
        private readonly string filePath = @"C:\connection.txt";
        private string connectionString;

        /// <summary>
        /// Initializes a new instance of the DatabaseConnection class and loads the connection string from a file.
        /// </summary>
        internal DatabaseConnection()
        {
            LoadConnectionString();
        }

        /// <summary>
        /// Loads the connection string from a file.
        /// </summary>
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

        /// <summary>
        /// Gets a MySqlConnection object using the loaded connection string.
        /// </summary>
        internal MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
