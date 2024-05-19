using H2_Assigment_Bagagesorteringssystem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    /// <summary>
    /// Represents a terminal in the airport responsible for managing baggage and interacting with planes.
    /// </summary>
    internal class Terminal : InventoryContainer
    {
        private bool _status = false;
        private Plane _plane;

        internal event EventHandler TerminalStatusChanged;

        internal bool Status
        {
            get { return _status; }
        }

		internal Plane Plane
		{
			get { return _plane; }
			set { _plane = value; }
		}

        /// <summary>
        /// Initializes a new instance of the Terminal class with the specified inventory size.
        /// </summary>
        /// <param name="inventorySize">The maximum inventory size of the terminal.</param>
        public Terminal(int inventorySize) : base(inventorySize) { }

        /// <summary>
        /// Opens the terminal.
        /// </summary>
        internal void Open()
		{
			_status = true;
            TerminalStatusChanged?.Invoke(this, EventArgs.Empty);
            Console.WriteLine("Opened a terminal");
        }

        /// <summary>
        /// Closes the terminal.
        /// </summary>
        internal void Close()
		{
			_status = false;
            TerminalStatusChanged?.Invoke(this, EventArgs.Empty);
            Console.WriteLine("Closed a terminal");
        }

        /// <summary>
        /// Sends baggage from the terminal to the associated plane.
        /// </summary>
        internal void SendBaggageToPlane()
        {
            Baggage baggage = this.RemoveFromInventory();
            if (baggage != null)
            {
                _plane.AddToInventory(baggage);
                Console.WriteLine($"Terminal Addet baggage: {baggage.BagageNumber} to plane: {_plane.FlightNumber}");
            }
        }
    }
}
