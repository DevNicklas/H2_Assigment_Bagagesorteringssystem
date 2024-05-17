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
		/// <summary>
		/// Running the airport simulator
		/// </summary>
		public static void RunSimulator() 
		{
			while (Airport.Status)
			{
				foreach (Terminal terminal in Airport.Terminals)
				{
					// If there is no plane at the terminal, add a new plane
					if (terminal.Plane == null)
					{
						terminal.Plane = Airport.AddPlane(10);
						terminal.Open();
						for (int i = 0; i < terminal.Plane.InventorySize; i++)
						{
							Airport.IncomingBaggageQueue.Enqueue(new Baggage(terminal.Plane.FlightNumber));
						}
					}

					// If the plane's inventory is full, close the terminal and remove the plane
					else if (terminal.Plane.InventorySize <= terminal.Plane.Inventory.Count)
					{
						// Close the terminal after processing is complete
						terminal.Close();
						// Remove the plane from the terminal
						terminal.Plane = null;
					}
					Thread.Sleep(2000);
				}
				Thread.Sleep(10000);

			};
		}
	}
}
