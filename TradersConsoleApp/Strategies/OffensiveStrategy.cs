using TradersConsoleApp.Abstract;
using TradersConsoleApp.Infrastructure;

namespace TradersConsoleApp.Strategies
{
    public class OffensiveStrategy : Strategy
    {
        private bool _isLiar;
        private Trader _previousPartner;
        
        public override Strategy Clone() => new OffensiveStrategy();

        public override bool NextTurn(Trader partner)
        {
            if (_previousPartner != partner) _isLiar = false;
            _previousPartner = partner;
            
            if (partner?.IsLiar ?? false) _isLiar = true;
            return _isLiar;
        }
        public override StrategyType Type => StrategyType.Offensive;
    }
}




  

