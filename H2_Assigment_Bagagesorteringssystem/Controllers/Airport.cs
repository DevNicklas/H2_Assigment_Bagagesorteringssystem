using H2_Assigment_Bagagesorteringssystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
		internal static void RunAirport()
		{

            AddCheckIn();
            AddTerminal();

            Thread threadCheckin = new Thread();
            Thread threadTerminal = new Thread(Terminal.);
		}
		internal static void RunCheckIn()
		{
			
			while (true)
            {
                Baggage baggage = new Baggage();
                checkIn.ServicePassenger(baggage);

			}
		}
		internal static void RunTerminal()
		{
			Terminal Terminal = new Terminal(1);
			while (true)
			{

			}
		}

		internal static bool ChangeStatus()
        {
            if(_status)
            {
                _status = false;
            }
            else
            {
                _status = true;
            }
            return _status;
        }
        internal static void AddPlane(int size)
        {
			_planes.Add(new Plane(50, "New York", 180, new DateTime(2024, 5, 17, 14, 30, 0));
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
