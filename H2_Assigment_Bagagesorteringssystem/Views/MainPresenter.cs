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

            _view.ChangeStatusBtnClicked += OnAiportStatusBtnClicked;
        }

        private void OnAiportStatusBtnClicked(object sender, EventArgs e)
        {
            _view.UpdateStatusLabel(Airport.Status);
        }
    }
}
