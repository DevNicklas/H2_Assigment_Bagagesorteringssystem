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
        public event EventHandler ChangeStatusBtnClicked;

        public MainForm()
        {
			

			InitializeComponent();
			
		}

        private void toggleAirportStatusBtn_Click(object sender, EventArgs e)
        {
        }

        public void UpdateStatusLabel(bool status)
        {
            if(status)
            {
                airportStatusLabel.Text = "Status: Open";
            }
        }
    }
}
