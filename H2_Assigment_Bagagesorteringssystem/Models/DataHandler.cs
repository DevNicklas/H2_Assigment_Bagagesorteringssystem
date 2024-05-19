using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using H2_Assigment_Bagagesorteringssystem.Models;
using System.IO;
using MySqlX.XDevAPI;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    internal class DataHandler
    {
        private string filePath = @"C:\connection.txt";
        private string connectionString;

        /// <summary>
        /// Gets all the destinations from the database
        /// </summary>
        public void GetDestination()
        {
            try
            {
                connectionString = File.ReadAllText(filePath).Trim();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading the connection string from the file: {ex.Message}");
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    try
                    {
                        string query = "CALL GetDestinations()";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        List<Destination> destinations = new List<Destination>();

                        while (reader.Read())
                        {
                            int destinationId = Convert.ToInt32(reader["destination_id"]);
                            string city = reader["city"].ToString();
                            string country = reader["country"].ToString();
                            string airportCode = reader["airport_code"].ToString();

                            Destination destination = new Destination(city, country, airportCode);
                            destinations.Add(destination);
                        }
                        reader.Close();
                    }

                    catch
                    {
                        throw new Exception("Procedure GetDestinations does not exists");
                    }

                }
                catch (MySqlException mysqlEx)
                {
                    throw new Exception($"MySQL Error: Unable to connect to the database. {mysqlEx.Message}");
                }
            }
        }

        /// <summary>
        /// Gets all the passengers from the Database
        /// </summary>
        public void GetPassenger()
        {
            try
            {
                connectionString = File.ReadAllText(filePath).Trim();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading the connection string from the file: {ex.Message}");
            }


            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    try
                    {
                        string query = "CALL GetPassengers()";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        List<Passenger> passengers = new List<Passenger>();

                        while (reader.Read())
                        {
                            int passengerId = Convert.ToInt32(reader["passenger_id"]);
                            string firstName = reader["first_name"].ToString();
                            string lastName = reader["last_name"].ToString();
                            string passportNumber = reader["passport_number"].ToString();
                            int flightId = Convert.ToInt32(reader["flight_id"]);
                            string boardingPassNumber = reader["boarding_pass_number"].ToString();

                            Passenger passenger = new Passenger(firstName, lastName, passportNumber, flightId, boardingPassNumber);
                            passengers.Add(passenger);
                        }
                        reader.Close();
                    }

                    catch (Exception ex)
                    {
                        throw new Exception($"Could not get connection to the table. {ex.Message}");
                    }
                }
                catch (MySqlException mysqlEx)
                {
                    throw new Exception($"MySQL Error: Unable to connect to the database. {mysqlEx.Message}");
                }
            }
        }

        /// <summary>
        /// Gets all the flights from the Database
        /// </summary>
        public static void GetFlight()
        {
            string filePath = @"C:\connection.txt";
            string connectionString;

            try
            {
                connectionString = File.ReadAllText(filePath).Trim();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading the connection string from the file: {ex.Message}");
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    try
                    {
                        string query = "CALL GetFlights()";
                        MySqlCommand cmd = new MySqlCommand(query, conn);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        List<Plane> planes = new List<Plane>();

                        while (reader.Read())
                        {
                            int flightNumber = Convert.ToInt32(reader["flight_number"]);
                            string destination = reader["destination_id"].ToString();
                            int maxPassengers = Convert.ToInt32(reader["avaibale_seats"]);
                            DateTime departureTime = Convert.ToDateTime(reader["departure_time"]);

                            Plane plane = new Plane(flightNumber, destination, maxPassengers, departureTime);
                            planes.Add(plane);
                        }
                        reader.Close();
                    }

                    catch (Exception ex)
                    {
                        throw new Exception($"Could not get connection to the table. {ex.Message}");
                    }
                }
                catch (MySqlException mysqlEx)
                {
                    throw new Exception($"MySQL Error: Unable to connect to the database. {mysqlEx.Message}");
                }
            }
        }

        public static void DatahandlerTest()
        {
            GetFlight();
        }
    }
}
