using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
	/// <summary>
	/// Represents a container for managing a collection of baggage items.
	/// </summary>
	abstract class InventoryContainer
	{
		private List<Baggage> _inventory = new List<Baggage>();
		private int _inventorySize;

		internal InventoryContainer(int inventorySize)
		{
				this._inventorySize = inventorySize;
		}

        internal List<Baggage> Inventory
        {
            get
            {
                return _inventory;
            }
        }
        internal int InventorySize
        {
            get
            {
                return _inventorySize;
            }
        }

        /// <summary>
        /// Add baggage to inventory
        /// </summary>
        /// <param name="baggage"></param>
        /// <returns></returns>
        internal bool AddToInventory(Baggage baggage)
		{
			if(_inventorySize > Inventory.Count)
			{ 
				Inventory.Add(baggage); 
				return true; // Return true to indicate successful addition
			}
			return false; // Return false if inventory is full
		}
		/// <summary>
		/// Remove baggage from inventory
		/// </summary>
		/// <returns></returns>
		internal Baggage RemoveFromInventory()
		{
			if (Inventory.Count > 0)
			{
				Baggage baggage = Inventory.First();
				Inventory.Remove(baggage);
				return baggage;
			}
			return null;
		}
	}
}
