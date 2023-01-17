using CsvHelper.Configuration;
using System;
using System.Reflection;

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


    public interface IOrder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int? StateId { get; set; }

    }


    public class Order : IOrder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int? StateId { get; set; }  


    }
}