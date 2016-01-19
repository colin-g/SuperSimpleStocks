using System;
using System.Collections.Generic;
using SuperSimpleStocks.Domain;

namespace SuperSimpleStocks.Calculations
{
    public interface ICalculationManager
    {
        double CalculateDividendYield(Stock stock);
        double CalculatePeRatio(Stock stock);
        double CalculateVolumeWeightedStockPrice(DateTime dateRangeStart, IEnumerable<Trade> trades);
        double CalculateGbceIndex(IEnumerable<Stock> stocks);
    }
}
