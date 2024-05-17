using H2_Assigment_Bagagesorteringssystem.Interfaces;
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
		internal static Queue<Baggage> IncomingBaggageQueue
		{
			get
			{
				return _incomingBaggageQueue;
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
			AddCheckIn();
			AddTerminal();
			AddTerminal();
			AddTerminal();
			AddSortingSystem();


			// Initialize and start the threads for check-in, terminal, and sorting systems
			StartThreads();

            ChangeStatus();

			foreach (CheckIn checkIn in _checkIns)
			{
				checkIn.Open();
			}


		}

		private static void StartThreads()
		{
			Thread threadCheckin = new Thread(RunCheckIn);
			Thread threadTerminal = new Thread(RunTerminal);
			Thread threadSort = new Thread(_sortingSystems[0].StartSystem);
			

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
							Thread.Sleep(200); // Simulate processing time
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
						Thread.Sleep(200); // Simulate processing time
					}
                }
            }
		}

		internal static void ChangeStatus()
        {
            if (_status)
            {
                _status = false;
            }
            else
            {
                _status = true;
				Thread threadSim = new Thread(Simulator.RunSimulator);
				threadSim.Start();
			}
			StatusChanged?.Invoke();
		}

        internal static Plane AddPlane(int size)
        {
			Random random = new Random();
			Plane plane = new Plane(random.Next(5, size + 1), "New York", size, new DateTime(2024, 5, 17, 14, 30, 0));
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
