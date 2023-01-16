using AlexanderLoftus_CodingAssessment.Services;


namespace AlexanderLoftus_CodingAssessmentNUnitTests
{
    public class MockDataBaseServiceTests
    {
        private MockDataBaseService MockDataBaseService { get; set; }

        [SetUp]
        public void Setup()
        {
            MockDataBaseService = new MockDataBaseService(this.GetType().Assembly.Location.Replace(this.GetType().Assembly.GetName().Name + ".dll", @"testDataBase\"));
        }


        [Test]
        public void OrdersCountTest()
        {
            Assert.AreEqual(MockDataBaseService.orders.Count, 5);
        }


        [Test]
        public void StatesCountTest()
        {
            Assert.AreEqual(MockDataBaseService.states.Count, 5);
        }

        [Test]
        public void OrderProductsCountTest()
        {
            Assert.AreEqual(MockDataBaseService.orderproducts.Count, 9);
        }

        [Test]
        public void ProductsCountTest()
        {
            Assert.AreEqual(MockDataBaseService.products.Count, 9);
        }

        [Test]
        public void CouponsCountTest()
        {
            Assert.AreEqual(MockDataBaseService.coupons.Count, 5);
        }

        [Test]
        public void PromotionsCountTest()
        {
            Assert.AreEqual(MockDataBaseService.promotions.Count, 3);
        }


        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void OrderHasOrderProducts_TestCase(int orderid)
        {
            Assert.AreNotEqual(MockDataBaseService.orderproducts.Where(x => x.OrderId == orderid).Count(), 0);
        }


        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void OrderHasStates_TestCase(int orderid)
        {
            Assert.AreNotEqual(MockDataBaseService.orders.Where(x => x.Id == orderid).FirstOrDefault().StateId, null);
        }
    }
}
