using H2_Assigment_Bagagesorteringssystem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models
{

    /// <summary>
    /// Represents a check-in counter in the baggage sorting system.
    /// </summary>
    internal class CheckIn : InventoryContainer
	{
        private bool _status = false;


        /// <summary>
        /// Gets the status of the check-in counter (open/closed).
        /// </summary>
        internal bool Status
        {
            get
            {
                return _status;
            }
        }

		internal CheckIn(int inventorySize) : base(inventorySize) { }


        /// <summary>
        /// Opens the check-in counter.
        /// </summary>
		internal void Open()
        {
            _status = true;
        }


        /// <summary>
        /// Closes the check-in counter.
        /// </summary>
        internal void Close()
        {
            _status = false;
        }


        /// <summary>
        /// Services a passenger by processing their baggage and sending it to the sorting system.
        /// </summary>
        /// <param name="baggage">The baggage to be processed.</param>
        internal bool ServicePassenger(Baggage baggage)
        {
            if (!_status) return false;

            GetBaggage(baggage);
            Thread.Sleep(100); // Simulate processing time
            SendBaggageToSortingSystem();
            return true;
        }

        /// <summary>
        /// Adds baggage to the check-in inventory.
        /// </summary>
        internal void GetBaggage(Baggage baggage)
        {
            this.AddToInventory(baggage);
        }

        /// <summary>
        /// Sends baggage from the check-in inventory to the sorting system for further processing.
        /// </summary>
        internal void SendBaggageToSortingSystem()
        {
            Baggage baggage = this.RemoveFromInventory();
            if (baggage != null)
            {
                Airport.SortingSystems[0].EnqueueBaggage(baggage);
            }
        }
    }
}
