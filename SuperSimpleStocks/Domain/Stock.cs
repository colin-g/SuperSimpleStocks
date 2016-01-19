namespace SuperSimpleStocks.Domain
{
    public class Stock
    {
        public string Symbol { get; set; }
        public StockType Type { get; set; }
        public double LastDividend { get; set; }
        public double? FixedDividend { get; set; }
        public double ParValue { get; set; }
        public double Price { get; set; }
    }
}
