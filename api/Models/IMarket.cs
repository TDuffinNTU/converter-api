using System;
using System.Collections.Generic;

namespace api.Models
{    
    public interface IMarket
    {
        public List<CurrencyPair> CurrencyPairs { get; set; }
        public DateTime LastUpdated { get; set; }    
        public void Update();
    }
}