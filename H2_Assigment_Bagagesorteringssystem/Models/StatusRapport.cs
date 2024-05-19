using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H2_Assigment_Bagagesorteringssystem.Controllers;
using System.IO;

namespace H2_Assigment_Bagagesorteringssystem.Models
{
    internal class StatusRapport
    {
        // Method to generate report content
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
        // Method to write the report to a text file
        public void WriteReportToFile(string filePath)
        {
            string reportContent = GenerateReportContent();
            File.WriteAllText(filePath, reportContent);
            Console.WriteLine("Report generated successfully.");
        }
    }
}
