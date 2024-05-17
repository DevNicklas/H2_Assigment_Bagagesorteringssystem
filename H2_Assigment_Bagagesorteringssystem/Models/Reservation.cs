using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
	internal class Reservation
	{
		private Passenger _passenger;
		private Plane _plane;
		private Baggage _bagage;

		internal Reservation(Passenger passenger, Plane plane, Baggage bagage)
		{
			_passenger = passenger;
			_plane = plane;
			_bagage = bagage;
		}	
	}
}
