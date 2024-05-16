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
		protected List<Baggage> inventory;
		private int _inventorySize;

		internal int InventorySize 
		{
            get
            {
                return _inventorySize;
            }
		}


	internal InventoryContainer(int inventorySize)
		{
			this._inventorySize = inventorySize;
		}
		/// <summary>
		/// Add baggage to inventory
		/// </summary>
		/// <param name="baggage"></param>
		/// <returns></returns>
		internal bool AddToInventory(Baggage baggage)
		{
			if(_inventorySize > inventory.Count)
			{ 
				inventory.Add(baggage); 
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
			if (inventory.Count > 0)
			{
				Baggage baggage = inventory.First();
				inventory.Remove(baggage);
				return baggage;
			}
			return null;
		}
	}
}
