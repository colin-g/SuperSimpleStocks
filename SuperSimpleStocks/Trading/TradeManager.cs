using System.Collections.Generic;
using SuperSimpleStocks.Domain;

namespace SuperSimpleStocks.Trading
{
    /// <summary>
    /// responsible for managing trades
    /// </summary>
    public class TradeManager : ITradeManager
    {
        private List<Trade> _trades;

        public TradeManager()
        {
            _trades = new List<Trade>();
        }

        public string RecordTrade(Trade trade)
        {
            _trades.Add(trade);
            return trade.StockSymbol + " trade recorded";
        }

        public IEnumerable<Trade> GetTrades()
        {
            return _trades;
        }
    }
}
