﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    internal class Baggage
    {
        private float _weight = 0;

        internal Baggage()
        {
            Random rand = new Random();
            _weight = rand.Next(0, 21);
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