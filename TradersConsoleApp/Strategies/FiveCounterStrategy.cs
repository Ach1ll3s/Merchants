using TradersConsoleApp.Abstract;
using TradersConsoleApp.Infrastructure;

namespace TradersConsoleApp.Strategies
{
    public class FiveCounterStrategy : Strategy
    {
        private int _counter = 5;
        private bool _isLiar;

        public override Strategy Clone() => new FiveCounterStrategy();

        public override bool NextTurn(Trader partner)
        {
            if (partner == null || --_counter <= 0) return _isLiar;
            if (partner.IsLiar) _isLiar = true;
            else _isLiar = !_isLiar;

            return _isLiar;
        }
        public override StrategyType Type => StrategyType.FiveCounter;
    }
}
