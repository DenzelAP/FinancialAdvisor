using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAdvisor
{
    public class MockInformationProvider : IInformationProvider
    {
        private readonly Dictionary<string, decimal> _exchangeRates;

        public MockInformationProvider()
        {
            // Stel een lijst van wisselkoersen in (mock data)
            _exchangeRates = new Dictionary<string, decimal>
        {
            { "USD", 1.1m }, // USD naar EUR
            { "EUR", 1.0m }, // EUR naar EUR
            { "GBP", 0.85m }, // GBP naar EUR
            { "JPY", 120m }, // JPY naar EUR
            { "CNY", 7.8m }, // CNY naar EUR
        };
        }

        public decimal GetExchangeRate(string currency)
        {
            if (string.IsNullOrWhiteSpace(currency))
            {
                throw new InvalidInputException("Valuta mag niet leeg of null zijn.");
            }

            string normalizedCurrency = currency.ToUpper();

            if (_exchangeRates.ContainsKey(normalizedCurrency)) // ContainsKey is een methode van Dictionary die controleert of de dictionary een bepaalde key bevat.
            {
                return _exchangeRates[normalizedCurrency];
            }
            else
            {
                throw new InvalidInputException($"Wisselkoers voor valuta '{currency}' niet gevonden.");
            }
        }

    }

}
