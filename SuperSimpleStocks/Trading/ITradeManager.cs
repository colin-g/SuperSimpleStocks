using System.Collections.Generic;
using SuperSimpleStocks.Domain;

namespace SuperSimpleStocks.Trading
{
    public interface ITradeManager
    {
        string RecordTrade(Trade trade);
        IEnumerable<Trade> GetTrades();
    }
}
