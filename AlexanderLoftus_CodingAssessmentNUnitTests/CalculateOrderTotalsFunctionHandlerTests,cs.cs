using AlexanderLoftus_CodingAssessment.Function_Handlers;
using AlexanderLoftus_CodingAssessment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexanderLoftus_CodingAssessmentNUnitTests
{
    public class CalculateOrderTotalsFunctionHandlerTests_cs
    {
        private CalculateOrderTotalsFunctionHandler CalculateOrderTotalsFunctionHandler { get; set; }
        [SetUp]
        public void Setup()
        {
            Microsoft.Azure.WebJobs.ExecutionContext executionContext = new Microsoft.Azure.WebJobs.ExecutionContext();
            executionContext.FunctionAppDirectory = this.GetType().Assembly.Location.Replace(this.GetType().Assembly.GetName().Name + ".dll", @"").Replace("NUnitTests",""); ;
            CalculateOrderTotalsFunctionHandler = new CalculateOrderTotalsFunctionHandler(executionContext);
        }


        [Test]
        public void OrdersCountTest()
        {
            Assert.AreEqual(CalculateOrderTotalsFunctionHandler.CalculateOrderTotals().Contains(".csv"),true);
        }
    }
}
