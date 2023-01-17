using CsvHelper.Configuration;
using System;


namespace AlexanderLoftus_CodingAssessment.Models
{
    public class PromotionMap : ClassMap<Promotion>
    {
        public PromotionMap()
        {
            Map(m => m.Id).Name("Id");
            Map(m => m.Name).Name("Name");
            Map(m => m.StartDate).Name("StartDate");
            Map(m => m.EndDate).Name("EndDate");
            Map(m => m.Amount).Name("Amount");
        }
    }

    public interface IPromotion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Double Amount { get; set; }
    }



    public class Promotion : IPromotion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Double Amount { get; set; }
    }
}