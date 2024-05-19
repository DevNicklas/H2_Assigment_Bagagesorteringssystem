using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H2_Assigment_Bagagesorteringssystem.Controllers;
using System.IO;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    /// <summary>
    /// Handles the generation and writing of status reports for the airport.
    /// </summary>
    internal class StatusRapport
    {
        /// <summary>
        /// Generates the content of the status report.
        /// </summary>
        /// <returns>A string containing the content of the status report.</returns>
        private string GenerateReportContent()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Airport Status Report");
            sb.AppendLine($"Date: {DateTime.Now}");
            sb.AppendLine();
            sb.AppendLine($"Total Flights Today: {Simulator.NumberOfTodaysFlights}");
            sb.AppendLine($"Total Passengers Today: {Simulator.NumberOfTodaysPassengers}");
            sb.AppendLine($"Total Baggage Today: {Simulator.NumberOfTodaysBaggage}");
            sb.AppendLine();

            return sb.ToString();
        }
        /// <summary>
        /// Writes the status report to a text file.
        /// </summary>
        /// <param name="filePath">The path of the file to write the report to.</param>
        internal void WriteReportToFile(string filePath)
        {
            string reportContent = GenerateReportContent();
            File.WriteAllText(filePath, reportContent);
            Console.WriteLine("Report generated successfully.");
        }
    }
}
