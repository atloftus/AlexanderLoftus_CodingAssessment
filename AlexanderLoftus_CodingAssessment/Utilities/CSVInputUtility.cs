using AlexanderLoftus_CodingAssessment.Models;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


namespace AlexanderLoftus_CodingAssessment.Utilities
{
    public static class CSVInputUtility { 
        #region METHOD
        public static async Task<MemoryStream> GetCSVMemoryStreamFromOrders(List<IOrderTotal> orders)
        {
            MemoryStream contentstream = new MemoryStream(50000);
            StreamWriter sw = new StreamWriter(contentstream);

            foreach (IOrderTotal order in orders) {
                if (sw.BaseStream.Position == 0) await sw.WriteLineAsync(order.ConvertPropertiesToCSVHeaderString());
                await sw.WriteLineAsync(order.ConvertToCSVString());
                sw.Flush();
            }           

            return contentstream;
        }
        #endregion
    }
}