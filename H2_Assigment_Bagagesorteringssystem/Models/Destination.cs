using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    /// <summary>
    /// Represents a destination for flights.
    /// </summary>
    internal class Destination
    {
        private string _city;
        private string _country;
        private string _airportCode;

        public string City { get { return _city; } }
        public string Country { get { return _country; } }
        public string AirportCode { get { return _airportCode; } }

        /// <summary>
        /// Initializes a new instance of the Destination class with the specified city, country, and airport code.
        /// </summary>
        /// <param name="city">The city of the destination.</param>
        /// <param name="country">The country of the destination.</param>
        /// <param name="airportCode">The airport code of the destination.</param>
        internal Destination(string city, string country, string airportCode)
        {
            _city = city;
            _country = country;
            _airportCode = airportCode;
        }
    }
}
