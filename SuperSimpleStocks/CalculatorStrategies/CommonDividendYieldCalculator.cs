namespace SuperSimpleStocks.CalculatorStrategies
{
    public class CommonDividendYieldCalculator : ICalculator
    {
        private readonly double _lastDividend;
        private readonly double _tickerPrice;

        public CommonDividendYieldCalculator(double lastDividend, double tickerPrice)
        {
            _lastDividend = lastDividend;
            _tickerPrice = tickerPrice;
        }

        public double Calculate()
        {
            if (_tickerPrice > 0)
            {
                return _lastDividend/_tickerPrice;
            }
            return 0;
        }
    }
}
