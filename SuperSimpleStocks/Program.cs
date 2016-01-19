using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSimpleStocks.Calculations;
using SuperSimpleStocks.Domain;
using SuperSimpleStocks.Trading;

namespace SuperSimpleStocks
{
    class Program
    {
        static void Main(string[] args)
        {
            // in this case Program.cs will act as the test harness - usually this code would live in its own unit test project

            // wire up implementations here - ideally use a DI tool for this
            ICalculationManager calculationManager = new CalculationManager();
            ITradeManager tradeManager = GetTradeManager();

            // setup test data
            Stock commonStock = GetSampleStock(11, "ALE", StockType.Common, 23, null, 60);
            Stock preferredStock = GetSampleStock(15, "GIN", StockType.Preferred, 8, 2, 100);
            Trade trade = GetSampleTrade(1.34, true, 25, "GIN", DateTime.Now);
            IEnumerable<Stock> stocks = GetSampleListOfStocks();
            DateTime fifteenMinutesAgo = DateTime.Now.Add(new TimeSpan(0, 0, -15));
            
            // tests
            // 1.a.i
            Console.WriteLine("Dividend yield for common stock: " + calculationManager.CalculateDividendYield(commonStock));
            Console.WriteLine("Dividend yield for preferred stock: " + calculationManager.CalculateDividendYield(preferredStock));

            // 1.a.ii
            Console.WriteLine("P/E Ratio: " + calculationManager.CalculatePeRatio(commonStock));

            // 1.a.iii
            Console.WriteLine("Recording Trade: " + tradeManager.RecordTrade(trade));

            // 1.a.iv
            Console.WriteLine("Volume weighted stock price: " + calculationManager.CalculateVolumeWeightedStockPrice(fifteenMinutesAgo, tradeManager.GetTrades()));

            // 1.b
            Console.WriteLine("GBCE All Share Index: " + calculationManager.CalculateGbceIndex(stocks));

            Console.ReadLine();
        }

        private static IEnumerable<Stock> GetSampleListOfStocks()
        {
            List<Stock> stocks = new List<Stock>
            {
                GetSampleStock(12, "TEA", StockType.Common, 0, null, 100),
                GetSampleStock(23, "POP", StockType.Common, 8, null, 100),
                GetSampleStock(11, "ALE", StockType.Common, 23, null, 60),
                GetSampleStock(15, "GIN", StockType.Preferred, 8, 2, 100),
                GetSampleStock(16, "JOE", StockType.Common, 13, null, 250)
            };

            return stocks;
        }

        private static ITradeManager GetTradeManager()
        {
            ITradeManager tradeManager = new TradeManager();

            int twentyMinutesAgo = -20;
            int thirtyMinutesAgo = -30;
            int fiveMinutesAgo = -5;

            tradeManager.RecordTrade(GetSampleTrade(225, true, 34, "TEA", DateTime.Now.Add(new TimeSpan(0, 0, twentyMinutesAgo))));
            tradeManager.RecordTrade(GetSampleTrade(226, true, 58, "TEA", DateTime.Now.Add(new TimeSpan(0, 0, thirtyMinutesAgo))));
            tradeManager.RecordTrade(GetSampleTrade(230, true, 12, "TEA", DateTime.Now.Add(new TimeSpan(0, 0, fiveMinutesAgo))));
            tradeManager.RecordTrade(GetSampleTrade(245, true, 19, "TEA", DateTime.Now));
            tradeManager.RecordTrade(GetSampleTrade(2578, true, 44, "POP", DateTime.Now.Add(new TimeSpan(0, 0, twentyMinutesAgo))));
            tradeManager.RecordTrade(GetSampleTrade(6826, true, 42, "ALE", DateTime.Now.Add(new TimeSpan(0, 0, thirtyMinutesAgo))));
            tradeManager.RecordTrade(GetSampleTrade(7230, true, 123, "GIN", DateTime.Now.Add(new TimeSpan(0, 0, fiveMinutesAgo))));
            tradeManager.RecordTrade(GetSampleTrade(145, true, 68, "JOE", DateTime.Now));

            return tradeManager;
        }

        private static Trade GetSampleTrade(double price, bool buy, double sharesQuantity, string stockSymbol, DateTime timeStamp)
        {
            return new Trade
            {
                Price = price,
                Buy = buy,
                SharesQuantity = sharesQuantity,
                StockSymbol = stockSymbol,
                TimeStamp = timeStamp
            };
        }

        private static Stock GetSampleStock(double price, string symbol, StockType type, double lastDividend, double? fixedDividend, double parValue)
        {
            return new Stock
            {
                Price = price,
                Symbol = symbol,
                Type = type,
                LastDividend = lastDividend,
                FixedDividend = fixedDividend,
                ParValue = parValue
            };
        }
    }
}
