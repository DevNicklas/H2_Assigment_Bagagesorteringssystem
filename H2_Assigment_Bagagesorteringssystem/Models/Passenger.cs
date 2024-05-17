using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    internal class Passenger
    {
        private string _firstName;
        private string _lastName;
        private string _passportNumber;
        private int _flightId;
        private string _boardingPassNumber;

        internal string FirstName { get { return _firstName; } }
		internal string LastName { get { return _lastName; } }
		internal string PassportNumber { get { return _passportNumber; } }
		internal int FlightId { get { return _flightId; } }
		internal string BoardingPassNumber { get { return _boardingPassNumber; } }

        internal Passenger(string firstName, string lastName, string passportNumber, int flightId, string boardingPassNumber)
        {
            _firstName = firstName;
            _lastName = lastName;
            _passportNumber = passportNumber;
            _flightId = flightId;
            _boardingPassNumber = boardingPassNumber;
        }
    }
}
