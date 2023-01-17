using CsvHelper.Configuration;
using System;


namespace AlexanderLoftus_CodingAssessment.Models
{
    public class CouponMap : ClassMap<Coupon> {
        public CouponMap() {
            Map(m => m.Id).Name("Id");
            Map(m => m.Amount).Name("Amount");
            Map(m => m.StartDate).Name("StartDate");
            Map(m => m.EndDate).Name("EndDate");
        }
    }

    public interface ICoupon
    {
        public int Id { get; set; }
        public Double Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class Coupon : ICoupon
    {
        public int Id { get; set; }
        public Double Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}