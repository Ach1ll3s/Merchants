using TradersConsoleApp.Abstract;
using TradersConsoleApp.Infrastructure;

namespace TradersConsoleApp.Strategies
{
    public class CheaterStategy : Strategy
    {
        public override Strategy Clone() => new CheaterStategy();
        public override bool NextTurn(Trader partner) => true;
        public override StrategyType Type => StrategyType.Cheater;
        
    }
}
