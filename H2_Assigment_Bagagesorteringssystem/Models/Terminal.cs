using H2_Assigment_Bagagesorteringssystem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    internal class Terminal : InventoryContainer
    {
        private bool _status = false;
        private Plane _plane;

        internal bool Status
        {
            get { return _status; }
        }

		internal Plane Plane
		{
			get { return _plane; }
			set { _plane = value; }
		}

		public Terminal(int inventorySize) : base(inventorySize) { }


		internal void Open()
		{
			_status = true;
		}

		internal void Close()
		{
			_status = false;
		}

        internal void SendBaggageToPlane()
        {
            Baggage baggage = this.RemoveFromInventory();
            if (baggage != null)
            {
                _plane.AddToInventory(baggage);
            }
        }
    }
}
