using System;
using TradersConsoleApp.Abstract;
using TradersConsoleApp.Infrastructure;

namespace TradersConsoleApp.Strategies
{
    public class RandomStrategy : Strategy
    {
        public override Strategy Clone() => new RandomStrategy();
        public override bool NextTurn(Trader partner) => Random.Next(2) == 1;
        public override StrategyType Type => StrategyType.Random;
    }
}
