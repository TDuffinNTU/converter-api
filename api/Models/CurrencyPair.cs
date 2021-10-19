using System;
namespace api.Models
{
    /// <summary>
    /// Represents a pair of currencies and their current exchange rate
    /// </summary>
    public class CurrencyPair
    {
        public Currency Base { get; set; }
        public Currency Quote { get; set; }
        public double Value { get; set; }   
    }
}