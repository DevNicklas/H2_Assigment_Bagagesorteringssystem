using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models.Database
{
    internal class PassengerData
    {
        private readonly DatabaseConnection _dbConnection;
        private List<Passenger> _passengers = new List<Passenger>();

        internal PassengerData(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        internal List<Passenger> Passengers
        {
            get
            {
                return _passengers;
            }
        } 

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
