namespace SuperSimpleStocks.CalculatorStrategies
{
    public class PreferredDividendYieldCalculator : ICalculator
    {
        private readonly double _fixedDividend;
        private readonly double _parValue;
        private readonly double _tickerPrice;

        public PreferredDividendYieldCalculator(double fixedDividend, double parValue, double tickerPrice)
        {
            _fixedDividend = fixedDividend;
            _parValue = parValue;
            _tickerPrice = tickerPrice;
        }

        public double Calculate()
        {
            if (_tickerPrice > 0)
            {
                return _fixedDividend *_parValue/_tickerPrice;
            }

            return 0;
        }
    }
}
