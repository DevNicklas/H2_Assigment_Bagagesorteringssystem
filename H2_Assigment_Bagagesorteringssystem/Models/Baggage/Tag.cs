using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
	internal class Tag 
	{
		private int _flightNumber;
		private string _bagageNumber;

		internal int FlightNumber
		{
			get { return _flightNumber; }
		}
		internal int BagageNumber
		{
			get { return _bagageNumber; }
		}
	}
}
