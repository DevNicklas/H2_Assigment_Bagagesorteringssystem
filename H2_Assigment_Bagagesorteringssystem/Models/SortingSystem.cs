using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using H2_Assigment_Bagagesorteringssystem;
using H2_Assigment_Bagagesorteringssystem.Controllers;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    internal class SortingSystem: InventoryContainer
    {
        private Queue<Baggage> _inputQueue = new Queue<Baggage>();
        private readonly object _lock = new object(); // Lock object for synchronization

        internal event EventHandler AddToSortingQueue;
        internal event EventHandler RemoveFromSortingQueue;

        private Baggage _newlyQueuedBaggage;
        private Baggage _newlyDequeuedBaggage;


        internal SortingSystem(int inventorySize) : base(inventorySize) { }

        internal Baggage NewlyQueuedBaggage
        {
            get
            {
                return _newlyQueuedBaggage;
            }
        }

        internal Baggage NewlyDequeuedBaggage
        {
            get
            {
                return _newlyDequeuedBaggage;
            }
        }

        /// <summary>
        /// Initiates the baggage sorting system and begins processing incoming baggage.
        /// </summary>
        internal void StartSystem()
		{
            ProcessBaggage();
        }

        /// <summary>
        /// Processes the incoming baggage items from the input queue.
        /// Dequeues baggage items from the input queue and sorts them using the Sort method.
        /// </summary>
        private void ProcessBaggage()
        {
            while (true)
            {
                Baggage baggage = null;
                lock (_lock) // Locking to ensure thread safety
                {
                    if (_inputQueue.Count > 0)
                    {
                        baggage = _inputQueue.Dequeue();
                        _newlyDequeuedBaggage = baggage;
                        RemoveFromSortingQueue?.Invoke(this, EventArgs.Empty);
                    }
                }
                if (baggage != null)
                {
                    Sort(baggage);
                }
                Thread.Sleep(200);
            }
        }

        /// <summary>
        /// Adds a new baggage item to the input queue for sorting.
        /// </summary>
        /// <param name="baggage">The baggage item to be added to the input queue.</param>
        internal void EnqueueBaggage(Baggage baggage)
        {
            _inputQueue.Enqueue(baggage);
            _newlyQueuedBaggage = baggage;
            AddToSortingQueue?.Invoke(this, EventArgs.Empty);
        }


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
            EnqueueBaggage(baggage);
		}
    }
}
