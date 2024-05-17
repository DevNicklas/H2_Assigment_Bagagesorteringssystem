﻿using H2_Assigment_Bagagesorteringssystem.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H2_Assigment_Bagagesorteringssystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toggleAirportStatusBtn_Click(object sender, EventArgs e)
        {
            if(Airport.ChangeStatus())
            {
                airportStatusLabel.Text = "Status: Open";
            }
            else
            {
                airportStatusLabel.Text = "Status: Closed";
            }
        }
    }
}
