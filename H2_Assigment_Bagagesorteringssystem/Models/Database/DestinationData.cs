using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models.Database
{
    /// <summary>
    /// Handles data retrieval for destinations from the database.
    /// </summary>
    internal class DestinationData
    {
        private readonly DatabaseConnection _dbConnection;
        private List<Destination> _destinations = new List<Destination>();

        internal DestinationData(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Gets the list of destinations fetched from the database.
        /// </summary>
        internal List<Destination> Destinations
        {
            get
            {
                return _destinations;
            }
        }
        /// <summary>
        /// Initializes a new instance of the DestinationData class with the specified database connection.
        /// </summary>
        /// <param name="dbConnection">The database connection to use for fetching destinations.</param>
        internal void FetchDestinations()
        {
            MySqlConnection conn = _dbConnection.GetConnection();

            using (conn)
            {
                try
                {
                    conn.Open();

                    const string QUERY = "CALL GetDestinations()";
                    MySqlCommand cmd = new MySqlCommand(QUERY, conn);

                    using (cmd)
                    {
                        MySqlDataReader reader = cmd.ExecuteReader();

                        using (reader)
                        {
                            while (reader.Read())
                            {
                                Destination destination = new Destination(
                                    reader["city"].ToString(),
                                    reader["country"].ToString(),
                                    reader["airport_code"].ToString()
                                );
                                _destinations.Add(destination);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error fetching destinations: " + ex.Message);
                }
            }
        }
    }
}
