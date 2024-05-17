using H2_Assigment_Bagagesorteringssystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H2_Assigment_Bagagesorteringssystem.Interfaces
{
    internal interface IView
    {
        void UpdateAirportStatusLabel();

        void UpdateCheckInSignStatus(sbyte idx, bool status);

        void UpdateTerminalSignStatus(sbyte idx, bool status);
    }
}
