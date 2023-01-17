using AlexanderLoftus_CodingAssessment.Models;
using AlexanderLoftus_CodingAssessment.Services;
using Microsoft.Azure.WebJobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexanderLoftus_CodingAssessment.Utilities
{
    public class CSVOutputUtility
    {
        public static string CreateOutputFile(ExecutionContext Context, List<IOrderTotal> orders)
        {
            string OutputFilePath = Context.FunctionAppDirectory + @"\Output\RunAt_" + DateTime.Now.ToString("yyyy-MM-dd---hh-mm-ss") + ".csv";
            using (FileStream fs = File.Create(OutputFilePath))
            {
                byte[] fileContents = CSVInputUtility.GetCSVMemoryStreamFromOrders(orders).Result.ToArray();
                fs.Write(fileContents, 0, fileContents.Length);
            }

            return OutputFilePath;
        }
    }
}
