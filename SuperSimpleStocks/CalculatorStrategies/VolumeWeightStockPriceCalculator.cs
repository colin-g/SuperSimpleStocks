using System;
using System.Collections.Generic;
using System.Linq;
using SuperSimpleStocks.Domain;

namespace SuperSimpleStocks.CalculatorStrategies
{
    public class VolumeWeightStockPriceCalculator : ICalculator
    {
        private readonly IEnumerable<Trade> _trades;
        private readonly DateTime _beginningOfRange;

        public VolumeWeightStockPriceCalculator(IEnumerable<Trade> trades, DateTime beginningOfRange)
        {
            _trades = trades;
            _beginningOfRange = beginningOfRange;
        }

        public double Calculate()
        {
            // get all trades in requested range
            IEnumerable<Trade> tradesRange = _trades.Where(x => x.TimeStamp > _beginningOfRange);

            double totalTradePrice = 0;
            double totalTradeQuantity = 0;

            foreach (Trade trade in tradesRange)
            {
                totalTradePrice += trade.Price;
                totalTradeQuantity += trade.SharesQuantity;
            }

            if (totalTradeQuantity > 0)
            {
                return totalTradePrice/totalTradeQuantity;
            }

            return 0;
        }
    }
}
