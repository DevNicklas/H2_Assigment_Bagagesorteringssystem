using H2_Assigment_Bagagesorteringssystem.Controllers;
using H2_Assigment_Bagagesorteringssystem.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using H2_Assigment_Bagagesorteringssystem.Models;
namespace H2_Assigment_Bagagesorteringssystem
{
    public partial class MainForm : Form, IView
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of the toggleAirportStatusBtn button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An EventArgs that contains the event data.</param>
        private void toggleAirportStatusBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine(Airport.Status);
            // Check if the airport is currently not running
            if (!Airport.Status)
            {
                Airport.ChangeStatus();
            }
        }

        /// <summary>
        /// Update view for airport status
        /// </summary>
       void IView.UpdateAirportStatusLabel()
        {
            Console.WriteLine("e");
            if (airportStatusLabel.InvokeRequired)
            {
                airportStatusLabel.Invoke(new Action(UpdateAirportStatusLabel));
            }
            else
            {
                airportStatusLabel.Text = Airport.Status ? "Status: Open" : "Status: Closed";
            }
        }

        /// <summary>
        /// Update view for the status sign of a check-in
        /// </summary>
        /// <param name="idx">The check-in index</param>
        /// <param name="status">Status of check-in</param>
        void IView.UpdateCheckInSignStatus(sbyte idx, bool status)
        {
            // Make the sign for check-in to green or red
            Panel signCheckInToUpdate = idx == 1 ? signCheckIn2 : signCheckIn1;
            signCheckInToUpdate.BackColor = status ? Color.Green : Color.Red;
        }

        /// <summary>
        /// Update view for the status sign of a terminal
        /// </summary>
        /// <param name="idx">The check-in index</param>
        /// <param name="status">Status of check-in</param>
        void IView.UpdateTerminalSignStatus(sbyte idx, bool status)
        {
            // Make the sign for terminal to green or red
            Panel signTerminalToUpdate = idx == 1 ? signTerminal2 : signTerminal1;
            signTerminalToUpdate.BackColor = status ? Color.Green : Color.Red;

            PictureBox planeImageToUpdate = idx == 1 ? planeImage2 : planeImage1;

            // Invoke the update of planeImage1.Visible on the UI thread
            if (planeImageToUpdate.InvokeRequired)
            {
                planeImageToUpdate.Invoke((MethodInvoker)delegate
                {
                    planeImageToUpdate.Visible = status;
                });
            }
            else
            {
                planeImageToUpdate.Visible = status;
            }
        }

        void IView.AddToSortingQueue(Baggage baggage)
        {
            if (sortingSystemQueue.InvokeRequired)
            {
                sortingSystemQueue.Invoke((Action)(() =>
                {
                    sortingSystemQueue.Items.Add($"Weight: {baggage.Weight} | BagageNumber: {baggage.BaggageNumber} | FlightNumber:{baggage.FlightNumber}");
                }));
            }
            else
            {
                sortingSystemQueue.Items.Add($"Weight: {baggage.Weight} | BagageNumber: {baggage.BaggageNumber} | FlightNumber:{baggage.FlightNumber}");
            }
        }

        void IView.RemoveFromSortingQueue(Baggage baggage)
        {
            if (sortingSystemQueue.InvokeRequired)
            {
                sortingSystemQueue.Invoke((Action)(() =>
                {
                    sortingSystemQueue.Items.Remove($"Weight: {baggage.Weight} | BagageNumber: {baggage.BaggageNumber} | FlightNumber:{baggage.FlightNumber}");
                }));
            }
            else
            {
                sortingSystemQueue.Items.Remove($"Weight: {baggage.Weight} | BagageNumber: {baggage.BaggageNumber} | FlightNumber:{baggage.FlightNumber}");
            }
        }


        internal void UpdateAirportStatusLabel()
        {
            ((IView)this).UpdateAirportStatusLabel();
        }

        internal void UpdateCheckInSignStatus(sbyte idx, bool status)
        {
            ((IView)this).UpdateCheckInSignStatus(idx, status);
        }

        internal void UpdateTerminalSignStatus(sbyte idx, bool status)
        {
            ((IView)this).UpdateTerminalSignStatus(idx, status);
        }

        internal void AddToSortingQueue(Baggage baggage)
        {
            ((IView)this).AddToSortingQueue(baggage);
        }

        internal void RemoveFromSortingQueue(Baggage baggage)
        {
            ((IView)this).RemoveFromSortingQueue(baggage);
        }
    }
}
