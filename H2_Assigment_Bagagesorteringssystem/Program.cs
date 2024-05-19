using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using H2_Assigment_Bagagesorteringssystem.Controllers;
using H2_Assigment_Bagagesorteringssystem.Models;
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

            MainForm mainForm = new MainForm();

            Airport.InitializeAirport();

            new MainPresenter(mainForm);

            Application.Run(mainForm);
        }
    }
}
