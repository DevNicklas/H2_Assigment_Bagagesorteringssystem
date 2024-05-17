using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    internal class Destination
    {
        private string _city;
        private string _country;
        private string _airportCode;

        public string City { get { return _city; } }
        public string Country { get { return _country; } }
        public string AirportCode { get { return _airportCode; } }

        internal Destination(string city, string country, string airportCode)
        {
            this._city = city;
            this._country = country;
            this._airportCode = airportCode;
        }
    }
}
