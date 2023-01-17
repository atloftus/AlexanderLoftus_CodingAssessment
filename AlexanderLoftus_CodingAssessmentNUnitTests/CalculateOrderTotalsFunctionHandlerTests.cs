using AlexanderLoftus_CodingAssessment.Function_Handlers;
using AlexanderLoftus_CodingAssessment.Models;
using AlexanderLoftus_CodingAssessment.Services;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexanderLoftus_CodingAssessmentNUnitTests
{
    public class CalculateOrderTotalsFunctionHandlerTests
    {
        private CalculateOrderTotalsFunctionHandler _functionHandler;
        private Microsoft.Azure.WebJobs.ExecutionContext _context;
        private MockDataBaseService _mockDataBaseService;
        private List<Order> _testOrders;
        private List<OrderProduct> _testOrderProducts;
        private List<Product> _testProducts;
        private List<State> _testStates;
        private List<Promotion> _testPromotions;

        private CalculateOrderTotalsFunctionHandler CalculateOrderTotalsFunctionHandler { get; set; }
        [SetUp]
        public void Setup()
        {
            Microsoft.Azure.WebJobs.ExecutionContext executionContext = new Microsoft.Azure.WebJobs.ExecutionContext();
            executionContext.FunctionAppDirectory = this.GetType().Assembly.Location.Replace(this.GetType().Assembly.GetName().Name + ".dll", @"").Replace("NUnitTests","");
            CalculateOrderTotalsFunctionHandler = new CalculateOrderTotalsFunctionHandler(executionContext);
        }


        [Test]
        public void OrdersCount_Test()
        {
            Assert.AreEqual(CalculateOrderTotalsFunctionHandler.CalculateOrderTotals().Contains(".csv"),true);
        }

        [Test]
        public void CalculateTotalsForOrder_Test()
        {
            Assert.AreEqual(CalculateOrderTotalsFunctionHandler.CalculateOrderTotals().Contains(".csv"), true);
        }
    }
}
