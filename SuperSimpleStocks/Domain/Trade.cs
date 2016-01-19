using System;

namespace SuperSimpleStocks.Domain
{
    public class Trade
    {
        public DateTime TimeStamp { get; set; }
        public double Price { get; set; }
        public double SharesQuantity { get; set; }
        public bool Buy { get; set; }
        public string StockSymbol { get; set; }
    }
}
