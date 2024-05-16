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

        internal void Sort(Baggage baggage)
        {
            foreach (Terminal terminal in Airport.Terminals)
            {

            }

		}
        internal SortingSystem(int inventorySize) : base(inventorySize) { }
    }
}
