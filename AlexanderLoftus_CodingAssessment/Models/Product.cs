using CsvHelper.Configuration;
using System;


namespace AlexanderLoftus_CodingAssessment.Models
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Map(m => m.Id).Name("Id");
            Map(m => m.Name).Name("Name");
            Map(m => m.Price).Name("Price");
            Map(m => m.IsLuxuryGood).Name("IsLuxuryGood");
        }
    }


    public interface IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Double Price { get; set; }
        public bool IsLuxuryGood { get; set; }
    }


    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public Double Price { get; set; }
        public bool IsLuxuryGood { get; set; }
    }
}