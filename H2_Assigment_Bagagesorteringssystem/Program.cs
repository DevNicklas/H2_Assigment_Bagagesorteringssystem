using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using H2_Assigment_Bagagesorteringssystem.Controllers;
using H2_Assigment_Bagagesorteringssystem.Models;
using H2_Assigment_Bagagesorteringssystem.Models.Database;
using H2_Assigment_Bagagesorteringssystem.Views;

namespace H2_Assigment_Bagagesorteringssystem
{
    internal static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Make a connection with the database
            DatabaseConnection dbConnection = new DatabaseConnection();

            // Fetch destination Data
            DestinationData destinationData = new DestinationData(dbConnection);
            destinationData.FetchDestinations();

            // Fetch plane data
            PlaneData planeData = new PlaneData(dbConnection);
            //planeData.FetchFlights();

            // Fetch passenger data
            PassengerData passengerData = new PassengerData(dbConnection);
            passengerData.FetchPassengers();

            MainForm mainForm = new MainForm();

            Airport.InitializeAirport();

            new MainPresenter(mainForm);

            Application.Run(mainForm);
        }
    }
}
