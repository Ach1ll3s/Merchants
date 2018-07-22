using TradersConsoleApp.Abstract;

namespace TradersConsoleApp.Infrastructure
{
    public class Trader
    {
        public Strategy Strategy { get; }
        public int Money { get; private set; }
        public int Income { get; private set; }

        public Trader(Strategy strategy)
        {
            Strategy = strategy;
            _isLiar = Strategy.NextTurn(null);
        }

        private bool _isLiar;

        public bool IsLiar => Strategy.Random.NextDouble() < 0.05 ? !_isLiar : _isLiar;

        public void Deal(Trader partner)
        {

            var partnerIsLiar = partner.IsLiar;
            var iAmLiar = IsLiar;

            if (partnerIsLiar) Income += iAmLiar ? 2 : 1;
            else Income += iAmLiar ? 5 : 4;

            _isLiar = Strategy.NextTurn(partner);
        }

        public void NextYear()
        {
            Money += Income;
            Income = 0;
        }

        public Trader Clone() => new Trader(Strategy.Clone()) { Income = Income, Money = Money };
    }
    public enum StrategyType
    {
        Altruist,
        Cheater,
        FiveCounter,
        Mimic,
        Offensive,
        Random,
        My
    }
}
