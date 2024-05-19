using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
	internal class Tag 
	{
		private int _flightNumber;
		private string _baggageNumber;

		internal int FlightNumber
		{
			get { return _flightNumber; }
		}
		internal string BagageNumber
		{
			get { return _baggageNumber; }
		}
		internal Tag(int flightNumber) 
		{
			_flightNumber = flightNumber;
			_baggageNumber = GenerateBaggageNumber();
		}

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
