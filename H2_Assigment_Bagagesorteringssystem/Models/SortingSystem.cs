using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H2_Assigment_Bagagesorteringssystem;
using H2_Assigment_Bagagesorteringssystem.Controllers;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    internal class SortingSystem: InventoryContainer
    {
        private Queue<Baggage> inputQueue;

		/// <summary>
		/// Sorts the given baggage to the appropriate terminal based on its flight number.
		/// If the baggage cannot be sorted to any terminal, it is enqueued in the input queue.
		/// </summary>
		/// <param name="baggage">The baggage to be sorted.</param>
		internal void Sort(Baggage baggage)
		{
			foreach (Terminal terminal in Airport.Terminals)
			{
				if (terminal.Plane != null && terminal.Plane.FlightNumber == baggage.FlightNumber)
				{
					if (terminal.AddToInventory(baggage))
					{
						return;
					}
				}
			}
			// If the baggage couldn't be sorted to any terminal, enqueue it in the input queue
			inputQueue.Enqueue(baggage);
		}
		internal SortingSystem(int inventorySize) : base(inventorySize) { }
    }
}
