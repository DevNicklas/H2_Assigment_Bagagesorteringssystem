﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    internal class Plane : InventoryContainer
    {
        private int _flightNumber;
		internal int FlightNumber
		{
			get { return _flightNumber; }
		}

		internal Plane(int inventorySize) : base(inventorySize) { }
	}

}
