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


    public class Product : TableBase
    {
        public string Name { get; set; }    
        public Double Price { get; set; }
        public bool IsLuxuryGood { get; set; }
    }
}