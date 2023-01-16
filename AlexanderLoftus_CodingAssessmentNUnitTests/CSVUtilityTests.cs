using AlexanderLoftus_CodingAssessment.Models;
using AlexanderLoftus_CodingAssessment.Utilities;


namespace AlexanderLoftus_CodingAssessmentNUnitTests
{
    public class CSVUtilityTests
    {

        [Test]
        public void GetCSVMemoryStreamFromOrders_Test()
        {
            Order testorder = new Order();
            testorder.Id = 1;
            testorder.Name = "Test Order";
            testorder.Date = new DateTime(2023, 1, 1);
            testorder.StateId = 1;
            testorder.PreTaxCost = 100.00;
            testorder.Tax = 10.00;
            testorder.Total = 90.00;

            List<Order> testorders = new List<Order>();
            testorders.Add(testorder);

            MemoryStream returnVal = CSVUtility.GetCSVMemoryStreamFromOrders(testorders).Result;

            Assert.AreEqual(returnVal.Length, 104);
        }
    }
}
