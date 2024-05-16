using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    internal class SortingSystem: InventoryContainer
    {
        private Queue<Baggage> inputQueue;

        internal void Sort(Baggage baggage)
        {

        }
        internal SortingSystem(int inventorySize) : base(inventorySize) { }
    }
}
