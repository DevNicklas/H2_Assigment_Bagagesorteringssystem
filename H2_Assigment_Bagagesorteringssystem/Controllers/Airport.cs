﻿using H2_Assigment_Bagagesorteringssystem.Interfaces;
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
    /// <summary>
    /// Represents the main airport system controller.
    /// </summary>
    internal static class Airport
    {
        private static List<Terminal> _terminals = new List<Terminal>();
        private static List<SortingSystem> _sortingSystems = new List<SortingSystem>();
		private static List<CheckIn> _checkIns = new List<CheckIn>();
		private static List<Plane> _planes = new List<Plane>();
		private static Queue<Baggage> _incomingBaggageQueue = new Queue<Baggage>();
        private static bool _status = false;

		internal static Action ChangeAirportStatus;

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
        /// <summary>
        /// Initializes the airport with terminals, check-in counters, and sorting systems.
        /// </summary>
        internal static void InitializeAirport()
		{
            for (int i = 0; i < 2; i++)
            {
                AddCheckIn();
                AddTerminal();
            }
            AddSortingSystem();
        }

        /// <summary>
        /// Starts the operations of the airport.
        /// </summary>
        internal static void RunAirport()
        {
			// Initialize and start the threads for check-in, terminal, and sorting systems
			StartThreads();

			foreach (CheckIn checkIn in _checkIns)
			{
				checkIn.Open();
			}


		}

        /// <summary>
        /// Starts threads for check-in, terminal, and sorting systems.
        /// </summary>
        private static void StartThreads()
		{
            if(_status)
            {
                Thread threadCheckin = new Thread(RunCheckIn);
                Thread threadTerminal = new Thread(RunTerminal);
                Thread threadSort = new Thread(_sortingSystems[0].StartSystem);
                Thread threadSim = new Thread(Simulator.RunSimulator);

                threadCheckin.Start();
                threadTerminal.Start();
                threadSort.Start();
                threadSim.Start();
            }

		}

        /// <summary>
        /// Manages the processing of baggage at check-in counters.
        /// </summary>
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
				Thread.Sleep(70);
			}
		}

        /// <summary>
        /// Manages the processing of baggage at terminals.
        /// </summary>
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

        /// <summary>
        /// Changes the status of the airport.
        /// </summary>
        internal static void ChangeStatus()
        {
            if (_status)
            {
                _status = false;
                ChangeAirportStatus?.Invoke();

                foreach (CheckIn checkIn in _checkIns)
				{
                    checkIn.Inventory.Clear();
                    checkIn.Close();
				}
                foreach (SortingSystem sortingSystem in _sortingSystems)
                {
                    sortingSystem.Inventory.Clear();
                }
                foreach (Terminal terminal in _terminals)
                {
                    terminal.Inventory.Clear();
                    terminal.Close();
                }

				_incomingBaggageQueue.Clear();
				_planes.Clear();
                Application.Exit();
            }
            else
            {
                _status = true;
                ChangeAirportStatus?.Invoke();
                RunAirport();
			}
        }

        /// <summary>
        /// Adds a ""random"" plane to the airport.
        /// </summary>
        internal static Plane AddRandomPlane()
		{
			return AddPlane(100, "KBH"); // Not random for now
		}
		/// <summary>
		/// Adds a new plane with a specified inventory size and destination to the airport.
		/// </summary>
		/// <param name="size">The maximum inventory size of the plane.</param>
		/// <param name="destination">The destination of the plane.</param>
		/// <returns>The newly created Plane object.</returns>
		internal static Plane AddPlane(int size, string destination)
        {
			Random random = new Random();
            int numberOfBaggage = random.Next(5, size + 1);

			Plane plane = new Plane(numberOfBaggage, destination, size, new DateTime(2024, 5, 17, 14, 30, 0));
			_planes.Add(plane);
            return plane;
		}

        /// <summary>
        /// Adds a new SortingSystems with inventory size of 1
        /// </summary>
        internal static void AddSortingSystem()
        {
            _sortingSystems.Add(new SortingSystem(1));
        }
        /// <summary>
        /// Adds a new CheckIn with inventory size of 1
        /// </summary>
		internal static void AddCheckIn()
        {
			_checkIns.Add(new CheckIn(1));
		}

        /// <summary>
        /// Adds a new Terminal with inventory size of 1
        /// </summary>
        internal static void AddTerminal()
        {
            _terminals.Add(new Terminal(1));
		}

    }
}
