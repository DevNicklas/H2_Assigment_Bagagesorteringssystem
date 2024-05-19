using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models.Database
{
    /// <summary>
    /// Handles data retrieval for planes from the database.
    /// </summary>
    internal class PlaneData
    {
        private readonly DatabaseConnection _dbConnection;
        private List<Plane> _planes = new List<Plane>();

        /// <summary>
        /// Initializes a new instance of the PlaneData class with the specified database connection.
        /// </summary>
        /// <param name="dbConnection">The database connection to use for fetching planes.</param>
        public PlaneData(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Gets the list of planes fetched from the database.
        /// </summary>
        internal List<Plane> Planes
        {
            get
            {
                return _planes;
            }
        }

        /// <summary>
        /// Fetches flights from the database and populates the Planes list.
        /// </summary>
        internal void FetchFlights()
        {
            MySqlConnection conn = _dbConnection.GetConnection();

            using (conn)
            {
                try
                {
                    conn.Open();

                    const string QUERY = "CALL GetFlights()";
                    MySqlCommand cmd = new MySqlCommand(QUERY, conn);

                    using (cmd)
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();

                        using (reader)
                        {
                            /*
                            while (reader.Read())
                            {
                                Plane plane = new Plane(
                                    Convert.ToInt32(reader["flight_number"]),
                                    Convert.ToDateTime(reader["departure_time"]),
                                    reader["destination_id"].ToString(),
                                    Convert.ToInt32(reader["available_seats"]),
                                    100
                                );
                                _planes.Add(plane);
                            }
                            */
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching flights: " + ex.Message);
                }
            }
        }
    }
}
