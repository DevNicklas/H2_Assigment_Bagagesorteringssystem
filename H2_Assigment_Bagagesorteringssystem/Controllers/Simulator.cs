using H2_Assigment_Bagagesorteringssystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Controllers
{
	internal static class Simulator
	{
		public static void RunSimulator() 
		{
			while (Airport.Status)
			{
				foreach (Terminal terminal in Airport.Terminals)
				{
					if (terminal.Plane == null)
					{
						terminal.Plane = Airport.AddPlane(100);
						terminal.Open();
						for (int i = 0; i < 100; i++)
						{
							Airport.IncomingBaggageQueue.Enqueue(new Baggage(terminal.Plane.FlightNumber));
						}
					}

					else
					{
						if (terminal.Plane.InventorySize <= terminal.Plane.Inventory.Count)
						{
							terminal.Close();
							terminal.Plane = null;
						}
					}
				}
				Thread.Sleep(2000);
			};
		}
	}
}
