using AlexanderLoftus_CodingAssessment.Models;
using AlexanderLoftus_CodingAssessment.Services;
using AlexanderLoftus_CodingAssessment.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace AlexanderLoftus_CodingAssessment.Function_Handlers
{
    public interface IFunctionHandler { 
        
    }


    public class CalculateOrderTotalsFunctionHandler 
    {
        #region PROPERTIES
        public MockDataBaseService MockDataBaseService { get; set; }
        public Microsoft.Azure.WebJobs.ExecutionContext Context { get; set; }
        #endregion



        #region CONSTRUCTOR
        public CalculateOrderTotalsFunctionHandler(Microsoft.Azure.WebJobs.ExecutionContext context) {
            MockDataBaseService = new MockDataBaseService(context.FunctionAppDirectory + @"\DataBase\");
            Context = context;
        }
        #endregion



        #region METHODS
        public string CalculateOrderTotals() 
        {
            List<IOrderTotal> OrderTotals = new List<IOrderTotal>();
            foreach (Order order in MockDataBaseService.orders) OrderTotals.Add(CalculateTotalsForOrder(order));
            return CSVOutputUtility.CreateOutputFile(Context, OrderTotals);
        }


        public IOrderTotal CalculateTotalsForOrder(Order order) 
        {
            IOrderTotal orderTotal = new OrderTotal();
            orderTotal.Order = order;
            Promotion? activepromotion = MockDataBaseService.promotions.Where(x => (x.StartDate < DateTime.Now) && (x.EndDate > DateTime.Now)).OrderByDescending(x => x.Amount).FirstOrDefault();
            List<OrderProduct> thisordersproducts = MockDataBaseService.orderproducts.Where(x => x.Order == order).ToList();

            foreach (OrderProduct orderproduct in thisordersproducts) orderTotal.PreTaxCost += orderproduct.Product.Price * orderproduct.Quantity;

            State orderstate = MockDataBaseService.states.Where(x => x.Id == order.StateId).FirstOrDefault();

            if (orderstate.CalculateTaxBefore) CalculateTotalsForPreTax(orderTotal, thisordersproducts, orderstate, activepromotion);
            else CalculateTotalsForPostTax(orderTotal, thisordersproducts, orderstate, activepromotion);

            return orderTotal;
        }


        public void CalculateTotalsForPreTax(IOrderTotal order, List<OrderProduct> thisordersproducts, State orderstate, Promotion? activepromotion) 
        {
            foreach (OrderProduct orderproduct in thisordersproducts)
            {
                Double discount = CalculateDiscount(orderproduct, activepromotion);
                Double finalPrice = orderproduct.Product.Price * orderproduct.Quantity;
                Double tax = (orderproduct.Product.IsLuxuryGood ? (orderproduct.Product.Price * orderstate.TaxRate) * 2 : orderproduct.Product.Price * orderstate.TaxRate) * orderproduct.Quantity;

                order.Tax += tax;
                order.Total += finalPrice + tax - discount;
            }
        }


        public void CalculateTotalsForPostTax(IOrderTotal order, List<OrderProduct> thisordersproducts, State orderstate, Promotion? activepromotion)
        {
            foreach (OrderProduct orderproduct in thisordersproducts)
            {               
                Double discount = CalculateDiscount(orderproduct, activepromotion);
                Double finalPrice = orderproduct.Product.Price * orderproduct.Quantity - discount;
                Double tax = orderproduct.Product.IsLuxuryGood ? (finalPrice * orderstate.TaxRate) * 2 : finalPrice * orderstate.TaxRate;

                Console.WriteLine("----------" + orderproduct.Product.Name + " (" + orderproduct.Quantity + " @ $" + orderproduct.Product.Price + ")----------");
                Console.WriteLine("(finalPrice - discount) + tax = TOTAL");
                Console.WriteLine("(" + finalPrice + " - " + discount + ") + " + tax  + " = " + (finalPrice + tax - discount));
                Console.WriteLine("-----------------------------------");

                order.Tax += tax;
                order.Total += finalPrice + tax;
            }
        }


        public Double CalculateDiscount(OrderProduct orderproduct, Promotion? activepromotion) {
            Double discount = 0.00;

            if (orderproduct.Coupon != null) discount += orderproduct.Coupon.Amount;

            if (activepromotion != null) discount += activepromotion.Amount;

            discount *= orderproduct.Quantity;

            return discount;
        }
        #endregion
    }
}