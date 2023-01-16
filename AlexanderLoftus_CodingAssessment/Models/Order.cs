using CsvHelper.Configuration;
using System;


namespace AlexanderLoftus_CodingAssessment.Models
{
    public class OrderMap : ClassMap<Order> { 
        public OrderMap() {
            Map(m => m.Id).Name("Id");
            Map(m => m.Name).Name("Name");
            Map(m => m.Date).Name("Date");
            Map(m => m.StateId).Name("StateId");
        }
    }



    public class Order : TableBase
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int? StateId { get; set; } = null;  
        public Double PreTaxCost { get; set; }
        public Double Tax { get; set; }
        public Double Total { get; set; }
    }
}