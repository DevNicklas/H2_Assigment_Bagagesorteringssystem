using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    /// <summary>
    /// Represents a passenger associated with a flight.
    /// </summary>
    internal class Passenger
    {
        private string _firstName;
        private string _lastName;
        private string _passportNumber;
        private int _flightNumber;
        private string _boardingPassNumber;

        internal string FirstName { get { return _firstName; } }
		internal string LastName { get { return _lastName; } }
		internal string PassportNumber { get { return _passportNumber; } }
		internal int FlightNumber { get { return _flightNumber; } }
		internal string BoardingPassNumber { get { return _boardingPassNumber; } }

        /// <summary>
        /// Initializes a new instance of the Passenger class with the specified details.
        /// </summary>
        /// <param name="firstName">The first name of the passenger.</param>
        /// <param name="lastName">The last name of the passenger.</param>
        /// <param name="passportNumber">The passport number of the passenger.</param>
        /// <param name="flightNumber">The flight number associated with the passenger.</param>
        /// <param name="boardingPassNumber">The boarding pass number of the passenger.</param>
        internal Passenger(string firstName, string lastName, string passportNumber, int flightNumber, string boardingPassNumber)
        {
            _firstName = firstName;
            _lastName = lastName;
            _passportNumber = passportNumber;
			_flightNumber = flightNumber;
            _boardingPassNumber = boardingPassNumber;
        }
    }
}
