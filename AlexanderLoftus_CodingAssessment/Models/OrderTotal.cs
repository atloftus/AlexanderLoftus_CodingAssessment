using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlexanderLoftus_CodingAssessment.Models
{
    public interface IOrderTotal
    {
        public IOrder Order { get; set; }
        public Double PreTaxCost { get; set; }
        public Double Tax { get; set; }
        public Double Total { get; set; }

        string ConvertPropertiesToCSVHeaderString();
        string ConvertToCSVString();
    }


    public class OrderTotal : IOrderTotal
    {
        public IOrder Order { get; set; }
        public Double PreTaxCost { get; set; }
        public Double Tax { get; set; }
        public Double Total { get; set; }


        #region METHODS
        public string ConvertPropertiesToCSVHeaderString()
        {
            string headerLine = "";

            bool isFirstProperty = true;

            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                if (isFirstProperty)
                {
                    if (property.Name.ToUpper() == "ORDER") { headerLine += "ORDER"; }
                    else { headerLine += property.Name.ToUpper(); }

                    isFirstProperty = false;
                }
                else {
                    if (property.Name.ToUpper() == "ORDER") { headerLine += ", ORDER"; }
                    else { headerLine += "," + property.Name.ToUpper(); }
                }
            }

            return headerLine;
        }


        public string ConvertToCSVString()
        {
            string retval = "";

            bool isFirstProperty = true;

            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                if (isFirstProperty)
                {
                    if (property.Name.ToUpper() == "ORDER") { retval += "\"" + this.Order.Name + "\""; }
                    else { retval += "\"" + property.GetValue(this) + "\""; }
                    
                    isFirstProperty = false;
                }
                else {
                    if (property.Name.ToUpper() == "ORDER") { retval += "," + "\"" + this.Order.Name + "\""; }
                    else { retval += "," + "\"" + property.GetValue(this) + "\""; }
                } 
            }

            return retval;
        }
        #endregion
    }
}
