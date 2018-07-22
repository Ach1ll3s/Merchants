using TradersConsoleApp.Abstract;
using TradersConsoleApp.Infrastructure;

namespace TradersConsoleApp.Strategies
{
    public class AltruistStategy : Strategy
    {
        public override Strategy Clone() => new AltruistStategy();
        public override bool NextTurn(Trader partner) => false;
        public override StrategyType Type => StrategyType.Altruist;
    }
}
