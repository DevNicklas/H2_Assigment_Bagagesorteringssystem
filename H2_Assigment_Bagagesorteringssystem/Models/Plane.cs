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
        private readonly DateTime _departure;
        private readonly string _destination;
        private readonly int _maxPassengers;


        internal Plane(int inventorySize, string destination, int maxPassengers, DateTime departure) : base(inventorySize)
        {
            _flightNumber = GenerateFlightNumber();
            _departure = departure;
            _destination = destination;
            _maxPassengers = maxPassengers;
        }

        public int FlightNumber => _flightNumber;
        public DateTime Departure => _departure;
        public string Destination => _destination;
        public int MaxPassengers => _maxPassengers;

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
