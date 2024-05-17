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
        event EventHandler ChangeStatusBtnClicked;

        void UpdateAirportStatusLabel(bool status);
        void UpdateCheckIn(bool status);
    }
}
