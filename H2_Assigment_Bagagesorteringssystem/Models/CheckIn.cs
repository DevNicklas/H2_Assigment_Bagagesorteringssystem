﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    internal class CheckIn : InventoryContainer
	{
        private bool _status = false;

        internal event Action StatusChanged;

        internal bool Status
        {
            get
            {
                return _status;
            }
        }

		internal CheckIn(int inventorySize) : base(inventorySize) { }

		internal void Open()
        {
            StatusChanged?.Invoke();
        }

        internal void Close()
        {
            StatusChanged?.Invoke();
        }
    }
}
