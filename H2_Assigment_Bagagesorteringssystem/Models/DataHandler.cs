using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    internal class DataHandler
    {
        public static void DatahandlerTest()
        {
            string filePath = @"C:\connection.txt";
            string connectionString;

            try
            {
                connectionString = File.ReadAllText(filePath).Trim();
                Console.WriteLine("Successfully read the connection string from the file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the connection string from the file: {ex.Message}");
                return;
            }

            Console.WriteLine($"Connection String: {connectionString}");

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    Console.WriteLine("Attempting to open the connection...");
                    conn.Open();
                    Console.WriteLine("Successfully connected to the database.");
                }
                catch (MySqlException mysqlEx)
                {
                    Console.WriteLine($"MySQL Error: Unable to connect to the database. {mysqlEx.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: Unable to connect to the database. {ex.Message}");
                }
            }
        }
    }
}
