using AlexanderLoftus_CodingAssessment.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;


namespace AlexanderLoftus_CodingAssessment.Services
{
    public class MockDataBaseService
    {
        public List<Order> orders { get; set; } = new List<Order>();
        public List<Coupon> coupons { get; set; } = new List<Coupon>();
        public List<Product> products { get; set; } = new List<Product>();
        public List<OrderProduct> orderproducts { get; set; } = new List<OrderProduct>();
        public List<Promotion> promotions { get; set; } = new List<Promotion>();
        public List<State> states { get; set; } = new List<State>();


        public MockDataBaseService(string folderpath) {
            SetupDatabase(folderpath);
            SetupDatabaseRelationships();
        }

        public void SetupDatabase(string folderpath)
        {
            SetOrders(folderpath);
            SetStates(folderpath);
            SetPromotions(folderpath);
            SetProducts(folderpath);
            SetOrderProducts(folderpath);
            SetCoupons(folderpath);
        }


        public void SetupDatabaseRelationships() 
        {
            foreach (OrderProduct orderproduct in orderproducts)
            {
                orderproduct.Order = orders.Where(x => x.Id == orderproduct.OrderId).FirstOrDefault();
                orderproduct.Product = products.Where(x => x.Id == orderproduct.ProductId).FirstOrDefault();
                orderproduct.Coupon = coupons.Where(x => x.Id == orderproduct.CouponId).FirstOrDefault();
            }
        }



        private void SetOrders(string folderpath) 
        {
            using (var reader = new StreamReader(folderpath + @"orders.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<OrderMap>();
                orders = csv.GetRecords<Order>().ToList();
            }
        }


        private void SetStates(string folderpath)
        {
            using (var reader = new StreamReader(folderpath + @"states.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<StateMap>();
                states = csv.GetRecords<State>().ToList();
            }
        }


        private void SetPromotions(string folderpath)
        {
            using (var reader = new StreamReader(folderpath + @"promotions.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<PromotionMap>();
                promotions = csv.GetRecords<Promotion>().ToList();
            }
        }


        private void SetProducts(string folderpath)
        {
            using (var reader = new StreamReader(folderpath + @"products.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ProductMap>();
                products = csv.GetRecords<Product>().ToList();
            }
        }


        private void SetOrderProducts(string folderpath)
        {
            using (var reader = new StreamReader(folderpath + @"orderproducts.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<OrderProductMap>();
                orderproducts = csv.GetRecords<OrderProduct>().ToList();
            }
        }

        private void SetCoupons(string folderpath)
        {
            using (var reader = new StreamReader(folderpath + @"coupons.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<CouponMap>();
                coupons = csv.GetRecords<Coupon>().ToList();
            }
        }

    }
}