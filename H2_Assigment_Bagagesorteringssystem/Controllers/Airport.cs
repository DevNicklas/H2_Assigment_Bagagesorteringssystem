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
        private static List<Terminal> _terminals = new List<Terminal>();
        private static List<SortingSystem> _sortingSystems = new List<SortingSystem>();
		private static List<CheckIn> _checkIns = new List<CheckIn>();
		private static List<Plane> _planes = new List<Plane>();
		private static Queue<Baggage> _incomingBaggageQueue = new Queue<Baggage>();
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
            AddSortingSystem();

			foreach (CheckIn checkIn in _checkIns)
			{
				checkIn.Open();
			}

			// Initialize and start the threads for check-in, terminal, and sorting systems
			StartThreads();

            ChangeStatus();


			while (_status)
            {
                foreach (Terminal terminal in _terminals)
                {
                    if (terminal.Plane == null)
                    {
                        terminal.Plane = AddPlane(100);
                        terminal.Open();
                        for (int i = 0; i < 100; i++)
                        {
                            _incomingBaggageQueue.Enqueue(new Baggage(terminal.Plane.FlightNumber));
                        }
                    }

                    else
                    {
						if (terminal.Plane.InventorySize <= terminal.Plane.Inventory.Count)
                        {
							terminal.Close();
                            terminal.Plane = null;
						}
					}
				}
                Thread.Sleep(2000);
			};
		}

		private static void StartThreads()
		{
			var threadCheckin = new Thread(RunCheckIn);
			var threadTerminal = new Thread(RunTerminal);
			var threadSort = new Thread(_sortingSystems[0].StartSystem);

			threadCheckin.Start();
			threadTerminal.Start();
			threadSort.Start();
		}
		internal static void RunCheckIn()
		{
			while (true)
            {
				foreach (var checkIn in _checkIns)
				{
					Baggage baggage = null;
					if (_incomingBaggageQueue.Count > 0)
					{
						lock (_incomingBaggageQueue)
						{
							if (_incomingBaggageQueue.Count > 0) // Double-check within the lock
							{
								baggage = _incomingBaggageQueue.Dequeue();
							}
						}
					}

					if (baggage != null)
					{
						lock (checkIn)
						{
							checkIn.ServicePassenger(baggage);
							Thread.Sleep(100); // Simulate processing time
						}
					}
				}
				Thread.Sleep(10);
			}
		}
		internal static void RunTerminal()
		{
            while (true)
            {
                foreach (Terminal terminal in _terminals)
                {
                    if (terminal.InventorySize > 0)
                    {
                        terminal.SendBaggageToPlane();
                    }
                }
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

        internal static Plane AddPlane(int size)
        {
            Plane plane = new Plane(50, "New York", 180, new DateTime(2024, 5, 17, 14, 30, 0));
			_planes.Add(plane);
            return plane;
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
