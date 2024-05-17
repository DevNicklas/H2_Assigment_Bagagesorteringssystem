using H2_Assigment_Bagagesorteringssystem.Controllers;
using H2_Assigment_Bagagesorteringssystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Views
{
    internal class MainPresenter
    {
        private IView _view;

        internal MainPresenter(IView view)
        {
            _view = view;

            Airport.CheckIns[0].CheckInStatusChanged += (sender, e) => OnCheckInStatusUpdate(0);
            Airport.CheckIns[1].CheckInStatusChanged += (sender, e) => OnCheckInStatusUpdate(1);

            Airport.Terminals[0].TerminalStatusChanged += (sender, e) => OnTerminalStatusUpdate(0);
            Airport.Terminals[1].TerminalStatusChanged += (sender, e) => OnTerminalStatusUpdate(1);
        }

        private void OnCheckInStatusUpdate(sbyte idx)
        {
            _view.UpdateCheckInSignStatus(idx, Airport.CheckIns[idx].Status);
        }

        private void OnTerminalStatusUpdate(sbyte idx)
        {
            _view.UpdateTerminalSignStatus(idx, Airport.Terminals[idx].Status);
        }
    }
}
