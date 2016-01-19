using System;
using System.Collections.Generic;
using SuperSimpleStocks.CalculatorStrategies;
using SuperSimpleStocks.Domain;

namespace SuperSimpleStocks.Calculations
{
    /// <summary>
    /// responsible for managing the calculations
    /// </summary>
    public class CalculationManager : ICalculationManager
    {
        public double CalculateDividendYield(Stock stock)
        {
            if (stock.Type == StockType.Common)
            {
                return new CommonDividendYieldCalculator(stock.LastDividend, stock.Price).Calculate();
            }

            return new PreferredDividendYieldCalculator(stock.FixedDividend.GetValueOrDefault(), stock.ParValue, stock.Price).Calculate();
        }

        public double CalculatePeRatio(Stock stock)
        {
            return new PeRatioCalculator(stock.Price, stock.LastDividend).Calculate();
        }
        
        public double CalculateVolumeWeightedStockPrice(DateTime dateRangeStart, IEnumerable<Trade> trades)
        {
            return new VolumeWeightStockPriceCalculator(trades, dateRangeStart).Calculate();
        }

        public double CalculateGbceIndex(IEnumerable<Stock> stocks)
        {
            return new CalculateGbceAllShareIndex(stocks).Calculate();
        }
    }
}
