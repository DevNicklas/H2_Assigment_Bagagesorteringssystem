using H2_Assigment_Bagagesorteringssystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Controllers
{
    internal class Airport
    {
        private List<Terminal> _terminals;
        private List<SortingSystem> _sortingSystems;
        private List<CheckIn> _checkIns;
        private List<Plane> _planes;
        private string _name;
        private bool _status;

        internal Airport(string name, bool status)
        {
            _name = name;
            _status = status;
        }

        internal void ChangeStatus()
        {
            if(_status)
            {
                _status = false;
            }
            else
            {
                _status = true;
            }
        }

        internal void AddPlane()
        {

        }

        internal void AddCheckIn()
        {

        }

        internal void AddTerminal()
        {

        }
    }
}
