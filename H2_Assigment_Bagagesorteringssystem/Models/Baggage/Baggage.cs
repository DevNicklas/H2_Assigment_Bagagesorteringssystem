using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    /// <summary>
    /// Represents a baggage item in the baggage sorting system, inheriting from Tag.
    /// </summary>
    internal class Baggage : Tag
    {
        private float _weight = 0;

        internal Baggage(int flightNumber) : base(flightNumber)
        {
            Random rand = new Random();
            _weight = rand.Next(1, 21);
        }

        internal float Weight
        {
            get
            {
                return _weight;
            }
        }
    }
}
