using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    /// <summary>
    /// Represents a tag associated with baggage, containing flight number and baggage number.
    /// </summary>
    internal class Tag 
	{
		private int _flightNumber;
		private string _baggageNumber;

        /// <summary>
        /// Initializes a new instance of the Tag class with the specified flight number.
        /// </summary>
        internal Tag(int flightNumber) 
		{
			_flightNumber = flightNumber;
			_baggageNumber = GenerateBaggageNumber();
		}

        internal int FlightNumber
        {
            get { return _flightNumber; }
        }
        internal string BagageNumber
        {
            get { return _baggageNumber; }
        }

        /// <summary>
        /// Generates a unique baggage number based on current ticks and random characters.
        /// </summary>
        private string GenerateBaggageNumber()
		{
			Thread.Sleep(1);
			int numbers = (int)(DateTime.Now.Ticks % int.MaxValue);
			string baggageNumber = numbers.ToString() + GenerateRandomCharacters();
			return baggageNumber;
		}

		/// <summary>
		/// Generates a string of 4 random characters from 'a' to 'z'.
		/// </summary>
		/// <returns>A string of 4 random lowercase letters.</returns>
		private string GenerateRandomCharacters()
		{
			Random random = new Random();
			char[] randomChars = new char[4];
			for (int i = 0; i < 4; i++)
			{
				randomChars[i] = (char)random.Next('a', 'z' + 1);
			}
			return new string(randomChars);
		}
	}
}
