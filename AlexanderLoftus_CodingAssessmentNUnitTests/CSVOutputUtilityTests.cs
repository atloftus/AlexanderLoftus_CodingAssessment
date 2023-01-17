using AlexanderLoftus_CodingAssessment.Models;
using AlexanderLoftus_CodingAssessment.Services;
using AlexanderLoftus_CodingAssessment.Utilities;
using Microsoft.Azure.WebJobs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExecutionContext = Microsoft.Azure.WebJobs.ExecutionContext;

namespace AlexanderLoftus_CodingAssessment.Tests
{
    [TestFixture]
    public class CSVOutputUtilityTests
    {
        private ExecutionContext _testContext;
        private List<IOrderTotal> _testOrders;
        private string _testOutputFilePath;

        [SetUp]
        public void Setup()
        {
            _testContext = new ExecutionContext();
            _testContext.FunctionAppDirectory = this.GetType().Assembly.Location.Replace(this.GetType().Assembly.GetName().Name + ".dll", @"").Replace("NUnitTests", "");
            _testOrders = new List<IOrderTotal>
            {
                new OrderTotal { Order = new Order { Id = 1, StateId = 1, Date = DateTime.Now }, PreTaxCost = 20, Tax = 2, Total = 22 },
                new OrderTotal { Order = new Order { Id = 2, StateId = 2, Date = DateTime.Now }, PreTaxCost = 30, Tax = 3, Total = 33 },
            };

            _testOutputFilePath = CSVOutputUtility.CreateOutputFile(_testContext, _testOrders);
        }

        [Test]
        public void CreateOutputFile_ShouldCreateCorrectFile()
        {
            var expectedResult = "ORDER,PRETAXCOST,TAX,TOTAL\r\n\"\",\"20\",\"2\",\"22\"\r\n\"\",\"30\",\"3\",\"33\"\r\n";
            var result = File.ReadAllText(_testOutputFilePath);
            Assert.AreEqual(expectedResult, result);
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_testOutputFilePath);
        }
    }
}

