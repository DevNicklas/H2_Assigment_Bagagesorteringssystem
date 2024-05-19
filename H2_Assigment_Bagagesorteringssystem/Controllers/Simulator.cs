using H2_Assigment_Bagagesorteringssystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Controllers
{
	/// <summary>
	/// Represents a static simulator for the airport baggage sorting system.
	/// </summary>
	internal static class Simulator
	{
		private const int TERMINAL_CHECK_INTERVAL = 5000;
		private const int SIMULATION_CYCLE_INTERVAL = 3000;

		/// <summary>
		/// Runs the airport simulator.
		/// </summary>
		internal static void RunSimulator()
		{
			while (Airport.Status)
			{
				foreach (var terminal in Airport.Terminals)
				{
					ProcessTerminal(terminal);
				}
				Thread.Sleep(SIMULATION_CYCLE_INTERVAL);
			}
		}

		/// <summary>
		/// Processes a terminal by either assigning a new plane or closing it if the plane is full.
		/// </summary>
		/// <param name="terminal">The terminal to be processed.</param>
		private static void ProcessTerminal(Terminal terminal)
		{
			if (terminal.Plane == null)
			{
				AssignNewPlaneToTerminal(terminal);
                Thread.Sleep(TERMINAL_CHECK_INTERVAL);
            }
			else if (terminal.Plane.InventorySize <= terminal.Plane.Inventory.Count)
			{
				CloseTerminalAndRemovePlane(terminal);
			}
			
		}

		/// <summary>
		/// Assigns a new plane to the terminal and enqueues its baggage.
		/// </summary>
		/// <param name="terminal">The terminal to which a new plane is assigned.</param>
		private static void AssignNewPlaneToTerminal(Terminal terminal)
		{
			Plane incomingPlane = Airport.AddRandomPlane();
			terminal.Plane = incomingPlane;
			GenerateNewBaggage(incomingPlane);
			terminal.Open();
		}

		private static void GenerateNewBaggage(Plane plane)
		{
			for (int i = 0; i < plane.InventorySize; i++)
			{
				Baggage baggage = new Baggage(plane.FlightNumber);

                Airport.IncomingBaggageQueue.Enqueue(baggage);
			}
		}

		/// <summary>
		/// Closes the terminal and removes the plane from it.
		/// </summary>
		/// <param name="terminal">The terminal to be closed.</param>
		private static void CloseTerminalAndRemovePlane(Terminal terminal)
		{
			terminal.Close();
			terminal.Plane = null;
		}

	}
}
