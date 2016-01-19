namespace SuperSimpleStocks.CalculatorStrategies
{
    public class PeRatioCalculator : ICalculator
    {
        private readonly double _price;
        private readonly double _dividend;

        public PeRatioCalculator(double price, double dividend)
        {
            _price = price;
            _dividend = dividend;
        }

        public double Calculate()
        {
            if (_dividend > 0)
            {
                return _price/_dividend;
            }
            return 0;
        }
    }
}
