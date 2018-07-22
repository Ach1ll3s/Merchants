using TradersConsoleApp.Abstract;
using TradersConsoleApp.Infrastructure;

namespace TradersConsoleApp.Strategies
{
    public class myStrategy : Strategy
    {
        private int _lostTimes = 1;

        public override Strategy Clone() => new myStrategy();

        public override bool NextTurn(Trader partner)
        {
            if (partner?.IsLiar ?? false) _lostTimes += 4;
            return --_lostTimes > 0;
        }
        public override StrategyType Type => StrategyType.My;
    }
}
