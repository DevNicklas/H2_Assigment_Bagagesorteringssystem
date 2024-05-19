using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    /// <summary>
    /// Represents a reservation linking a passenger, plane, and baggage.
    /// </summary>
    internal class Reservation
	{
		private Passenger _passenger;
		private Plane _plane;
		private Baggage _baggage;

        /// <summary>
        /// Initializes a new instance of the Reservation class with the specified passenger, plane, and baggage.
        /// </summary>
        /// <param name="passenger">The passenger associated with the reservation.</param>
        /// <param name="plane">The plane associated with the reservation.</param>
        /// <param name="bagage">The baggage associated with the reservation.</param>
        internal Reservation(Passenger passenger, Plane plane, Baggage baggage)
		{
			_passenger = passenger;
			_plane = plane;
			_baggage = baggage;
		}	
	}
}
