using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    internal class Plane : InventoryContainer
    {
        private readonly int _flightNumber;
        internal int FlightNumber => _flightNumber;

        private readonly string _destination;
        internal string Destination => _destination;

        private readonly int _maxPassengers;
        internal int MaxPassengers => _maxPassengers;

        private readonly DateTime _departure;
        internal DateTime Departure => _departure;

        internal Plane(int inventorySize, string destination, int maxPassengers, DateTime departure) : base(inventorySize)
        {
            _flightNumber = GenerateFlightNumber();
            _destination = destination;
            _maxPassengers = maxPassengers;
            _departure = departure;
        }

        /// <summary>
        /// Generates a unique flight number
        /// </summary>
        /// <returns></returns>
        private int GenerateFlightNumber()
        {
            // Uses DateTime ticks and a random number to generate a unique flight number
            Random random = new Random();
            return (int)(DateTime.Now.Ticks % int.MaxValue) + random.Next(1000, 9999);
        }
    }

}
