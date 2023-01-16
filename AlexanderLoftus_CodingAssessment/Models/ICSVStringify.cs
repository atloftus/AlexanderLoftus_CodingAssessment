using System.Reflection;


namespace AlexanderLoftus_CodingAssessment.Models
{
    public abstract class ICSVStringify
    {
        #region METHODS
        public string ConvertPropertiesToCSVHeaderString() {
            string headerLine = "";

            bool isFirstProperty = true;

            foreach (PropertyInfo property in typeof(Order).GetProperties())
            {
                if (isFirstProperty)
                {
                    headerLine += property.Name.ToUpper();
                    isFirstProperty = false;
                }
                else headerLine += "," + property.Name.ToUpper();
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
                    retval += "\"" + property.GetValue(this) + "\"";
                    isFirstProperty = false;
                }
                else retval += "," + "\"" + property.GetValue(this) + "\"";
            }

            return retval;
        }
        #endregion
    }
}