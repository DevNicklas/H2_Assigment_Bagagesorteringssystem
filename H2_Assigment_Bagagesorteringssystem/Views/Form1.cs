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
            // Check if the airport is currently not running
            if (!Airport.Status)
            {
                Airport.RunAirport();

                // Update the status label to reflect the change
                UpdateAirportStatusLabel();
            }
        }

        /// <summary>
        /// Update view for airport status
        /// </summary>
        public void UpdateAirportStatusLabel()
        {
            if (Airport.Status)
            {
                airportStatusLabel.Text = "Status: Open";
            }
            else
            {
                airportStatusLabel.Text = "Status: Closed";
            }
        }

        /// <summary>
        /// Update view for the status sign of a check-in
        /// </summary>
        /// <param name="idx">The check-in index</param>
        /// <param name="status">Status of check-in</param>
        public void UpdateCheckInSignStatus(sbyte idx, bool status)
        {
            Panel signCheckInToUpdate = idx == 1 ? signCheckIn2 : signCheckIn1;
            signCheckInToUpdate.BackColor = status ? Color.Green : Color.Red;
        }

        /// <summary>
        /// Update view for the status sign of a terminal
        /// </summary>
        /// <param name="idx">The check-in index</param>
        /// <param name="status">Status of check-in</param>
        public void UpdateTerminalSignStatus(sbyte idx, bool status)
        {
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
    }
}
