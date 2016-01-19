using System;
using System.Collections.Generic;
using System.Linq;
using SuperSimpleStocks.Domain;

namespace SuperSimpleStocks.CalculatorStrategies
{
    public class CalculateGbceAllShareIndex : ICalculator
    {
        private readonly IEnumerable<Stock> _stocks;

        public CalculateGbceAllShareIndex(IEnumerable<Stock> stocks)
        {
            _stocks = stocks;
        }

        public double Calculate()
        {
            double totalPrice = 0;

            foreach (Stock stock in _stocks)
            {
                totalPrice += stock.Price;
            }

            return Math.Pow(totalPrice, 1.00/_stocks.Count());
        }
    }
}
