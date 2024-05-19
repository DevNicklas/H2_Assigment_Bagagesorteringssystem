using H2_Assigment_Bagagesorteringssystem.Models;
using System;
using System.Linq;
using System.Threading;

namespace H2_Assigment_Bagagesorteringssystem.Controllers
{
    /// <summary>
    /// Represents a static simulator for the airport baggage sorting system.
    /// </summary>
    internal static class Simulator
    {
        private const int TERMINAL_CHECK_INTERVAL = 5000;
        private const int SIMULATION_CYCLE_INTERVAL = 3000;
        private const int _numberOfPerDayFlights = 10;

        private static int _numberOfTodaysFlights;
        private static int _numberOfTodaysPassengers;
        private static int _numberOfTodaysBaggage;

        internal static int NumberOfPerDayFlights
        {
            get
            {
                return _numberOfPerDayFlights;
            }
        }

        internal static int NumberOfTodaysFlights
        {
            get
            {
                return _numberOfTodaysFlights;
            }
        }

        internal static int NumberOfTodaysPassengers
        {
            get
            {
                return _numberOfTodaysPassengers;
            }
        }

        internal static int NumberOfTodaysBaggage
        {
            get
            {
                return _numberOfTodaysBaggage;
            }
        }

        /// <summary>
        /// Runs the airport simulator.
        /// </summary>
        internal static void RunSimulator()
        {
            while (Airport.Status)
            {
                foreach (Terminal terminal in Airport.Terminals)
                {
                    ProcessTerminal(terminal);
                }

                if (_numberOfPerDayFlights == _numberOfTodaysFlights && AreAllTerminalsClosed())
                {
                    Airport.ChangeStatus();
                    // Generate and write report
                    var report = new StatusRapport();
                    // Find it here: "bin\(Debug/Release)"
                    report.WriteReportToFile("AirportStatusReport.txt");

                }

                Thread.Sleep(SIMULATION_CYCLE_INTERVAL);
            }
        }

        /// <summary>
        /// Checks if all terminals are closed.
        /// </summary>
        /// <returns>True if all terminals are closed; otherwise, false.</returns>
        private static bool AreAllTerminalsClosed()
        {
            return Airport.Terminals.All(terminal => !terminal.Status);
        }

        /// <summary>
        /// Processes a terminal by either assigning a new plane or closing it if the plane is full.
        /// </summary>
        /// <param name="terminal">The terminal to be processed.</param>
        private static void ProcessTerminal(Terminal terminal)
        {
            if (terminal.Plane == null)
            {
                if (_numberOfPerDayFlights > _numberOfTodaysFlights)
                {
                    AssignNewPlaneToTerminal(terminal);
                }
            }
            else if (terminal.Plane.InventorySize <= terminal.Plane.Inventory.Count)
            {
                CloseTerminalAndRemovePlane(terminal);
            }
        }

        /// <summary>
        /// Assigns a new plane to the terminal and enqueues its baggage.
        /// </summary>
        /// <param name="terminal">The terminal to which a new plane is assigned.</param>
        private static void AssignNewPlaneToTerminal(Terminal terminal)
        {
            Plane incomingPlane = Airport.AddRandomPlane();
            terminal.Plane = incomingPlane;
            _numberOfTodaysFlights++;
            _numberOfTodaysPassengers += terminal.Plane.MaxPassengers;
            _numberOfTodaysBaggage += terminal.Plane.InventorySize;

            GenerateNewBaggage(incomingPlane);
            terminal.Open();

            Thread.Sleep(TERMINAL_CHECK_INTERVAL);
        }

        /// <summary>
        /// Generates new baggage for the given plane and enqueues it.
        /// </summary>
        /// <param name="plane">The plane for which baggage is generated.</param>
        private static void GenerateNewBaggage(Plane plane)
        {
            for (int i = 0; i < plane.InventorySize; i++)
            {
                Baggage baggage = new Baggage(plane.FlightNumber);
                Airport.IncomingBaggageQueue.Enqueue(baggage);
            }
        }

        /// <summary>
        /// Closes the terminal and removes the plane from it.
        /// </summary>
        /// <param name="terminal">The terminal to be closed.</param>
        private static void CloseTerminalAndRemovePlane(Terminal terminal)
        {
            terminal.Close();
            terminal.Plane = null;
        }
    }
}
