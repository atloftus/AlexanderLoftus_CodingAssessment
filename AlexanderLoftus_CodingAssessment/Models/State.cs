using CsvHelper.Configuration;
using System;


namespace AlexanderLoftus_CodingAssessment.Models
{
    public class StateMap : ClassMap<State>
    {
        public StateMap() {
            Map(m => m.Id).Name("Id");
            Map(m => m.Name).Name("Name");
            Map(m => m.TwoLetterSymbol).Name("TwoLetterSymbol");
            Map(m => m.CalculateTaxBefore).Name("CalculateTaxBefore");
            Map(m => m.TaxRate).Name("TaxRate");
        }
    }



    public class State : TableBase
    {
        public string Name { get; set; }
        public string TwoLetterSymbol { get; set; }
        public bool CalculateTaxBefore { get; set; }
        public Double TaxRate { get; set; }
    }
}