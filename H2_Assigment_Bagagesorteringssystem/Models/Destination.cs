﻿using System;
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

        internal Destination(string city, string country, string airportCode)
        {
            _city = city;
            _country = country;
            _airportCode = airportCode;
        }
    }
}