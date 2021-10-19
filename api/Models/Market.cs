using System.Reflection;
using System.Security.AccessControl;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace api.Models
{
    /// <summary>simulates a currency exchange market</summary>
    public class Market : IMarket
    {
        public List<Currency> Currencies { get; set; }               
        public List<CurrencyPair> CurrencyPairs { get; set; }
        public DateTime LastUpdated {get; set;}        
        private readonly ILogger _logger;
        private readonly Random _random;

        
        public Market(ILogger<Market> logger)
        {
            _logger = logger;
            _random = new Random();

            Currencies = new List<Currency>();
            CurrencyPairs = new List<CurrencyPair>();

            // create some currencies
            Currencies.Add(new Currency{Symbol = "£", ISO = "GBP", Country = "United Kingdom"});
            Currencies.Add(new Currency{Symbol = "$", ISO = "USD", Country = "United States of America"});
            Currencies.Add(new Currency{Symbol = "€", ISO = "EUR", Country = "European Union"});
            Currencies.Add(new Currency{Symbol = "₩", ISO = "KRW", Country = "South Korea"});
            Currencies.Add(new Currency{Symbol = "¥", ISO = "JPY", Country = "Japan"});
            Currencies.Add(new Currency{Symbol = "Kz", ISO = "AOA", Country = "Angola"});

            // generate rates for first time
            for (int i = 0; i < Currencies.Count - 1; i++)
            {               
                // ensure we don't pair currencies to themselves
                Currency[] not_i = (
                    from currency
                    in Currencies
                    where currency.ISO != Currencies[i].ISO
                    select currency
                    ).ToArray();


                for (int j = i + 1; j < Currencies.Count; j++)
                {
                    // create new currency pairs on first init                            
                    CurrencyPairs.Add(new CurrencyPair { Base = Currencies[i], Quote = Currencies[j], Value = GenerateRandomExchangeRate() });
                }
            }

            LastUpdated = DateTime.Now;
            _logger.LogInformation("Market Initialised.");
        }

        /// <summary>Generates random double between 1, 10</summary>
        private double GenerateRandomExchangeRate()
        {
            return Math.Round(_random.NextDouble() * 10d, 3);
        }
        
        /// <summary>Updates the values of exchange rates</summary>
        public void Update()
        {
            _logger.LogInformation("Updating IMarket");

            // update the values
            for(int i = 0; i < CurrencyPairs.Count; i++)
            {
                CurrencyPairs[i].Value = GenerateRandomExchangeRate();
            }

            LastUpdated = DateTime.Now;
        }
    }

}