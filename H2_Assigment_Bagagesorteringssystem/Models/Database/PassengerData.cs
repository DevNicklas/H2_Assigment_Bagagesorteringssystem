using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models.Database
{
    /// <summary>
    /// Handles data retrieval for passengers from the database.
    /// </summary>
    internal class PassengerData
    {
        private readonly DatabaseConnection _dbConnection;
        private List<Passenger> _passengers = new List<Passenger>();

        /// <summary>
        /// Initializes a new instance of the PassengerData class with the specified database connection.
        /// </summary>
        /// <param name="dbConnection">The database connection to use for fetching passengers.</param>
        internal PassengerData(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Gets the list of passengers fetched from the database.
        /// </summary>
        internal List<Passenger> Passengers
        {
            get
            {
                return _passengers;
            }
        }

        /// <summary>
        /// Fetches passengers from the database and populates the Passengers list.
        /// </summary>
        internal void FetchPassengers()
        {
            MySqlConnection conn = _dbConnection.GetConnection();

            using (conn)
            {
                try
                {
                    conn.Open();

                    const string QUERY = "CALL GetPassengers()";
                    MySqlCommand cmd = new MySqlCommand(QUERY, conn);

                    using (cmd)
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();

                        using (reader)
                        {
                            while (reader.Read())
                            {
                                Passenger passenger = new Passenger(
                                    reader["first_name"].ToString(),
                                    reader["last_name"].ToString(),
                                    reader["passport_number"].ToString(),
                                    Convert.ToInt32(reader["flight_id"]),
                                    reader["boarding_pass_number"].ToString()
                                );
                                _passengers.Add(passenger);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching passengers: " + ex.Message);
                }
            }
        }
    }
}
