using AlexanderLoftus_CodingAssessment.Models;
using AlexanderLoftus_CodingAssessment.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AlexanderLoftus_CodingAssessment.Tests
{
    [TestFixture]
    public class CSVInputUtilityTests
    {
        private List<IOrderTotal> _testOrders;
        private MemoryStream _testResult;

        [SetUp]
        public void Setup()
        {
            _testOrders = new List<IOrderTotal>
            {
                new OrderTotal { Order = new Order { Id = 1, Name = "A", StateId = 1, Date = DateTime.Now }, PreTaxCost = 20, Tax = 2, Total = 22 },
                new OrderTotal { Order = new Order { Id = 2, Name = "B", StateId = 2, Date = DateTime.Now }, PreTaxCost = 30, Tax = 3, Total = 33 },
            };

            _testResult = CSVInputUtility.GetCSVMemoryStreamFromOrders(_testOrders).Result;
            _testResult.Position = 0;
        }

        [Test]
        public void GetCSVMemoryStreamFromOrders_ShouldReturnCorrectCSVString()
        {
            var expectedResult = "ORDER,PRETAXCOST,TAX,TOTAL\r\n\"A\",\"20\",\"2\",\"22\"\r\n\"B\",\"30\",\"3\",\"33\"\r\n";
            var result = new StreamReader(_testResult).ReadToEnd();
            Assert.AreEqual(expectedResult, result);
        }
    }
}
