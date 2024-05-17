using H2_Assigment_Bagagesorteringssystem.Interfaces;
using H2_Assigment_Bagagesorteringssystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H2_Assigment_Bagagesorteringssystem.Controllers
{
    internal static class Airport
    {
        private static List<Terminal> _terminals;
        private static List<SortingSystem> _sortingSystems;
        private static List<CheckIn> _checkIns;
        private static List<Plane> _planes;
        private static string _name = "DinLufthavn";
        private static bool _status = false;

        internal static event Action StatusChanged;

        internal static List<Terminal> Terminals
        {
            get
            {
                return _terminals;
            }
        }

        internal static List<SortingSystem> SortingSystems
        {
            get
            {
                return _sortingSystems;
            }
        }

        internal static List<CheckIn> CheckIns
        {
            get
            {
                return _checkIns;
            }
        }

        internal static List<Plane> Planes
        {
            get
            {
                return _planes;
            }
        }

        internal static bool Status
        {
            get
            {
                return _status;
            }
        }

        internal static void ChangeStatus()
        {
            if(_status)
            {
                _status = false;
            }
            else
            {
                _status = true;
            }
            StatusChanged?.Invoke();
        }

        internal static void AddPlane(int size)
        {
			_planes.Add(new Plane(size));
		}
        internal static void AddSortingSystem()
        {
            _sortingSystems.Add(new SortingSystem(1));
        }

		internal static void AddCheckIn()
        {
			_checkIns.Add(new CheckIn(1));
		}

        internal static void AddTerminal()
        {
            _terminals.Add(new Terminal(1));
		}
    }
}
