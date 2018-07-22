using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TradersConsoleApp.Abstract;
using TradersConsoleApp.Properties;
using TradersConsoleApp.Strategies;

namespace TradersConsoleApp.Infrastructure
{
    public class Market : IEnumerable<Trader>
    {
        private readonly List<Trader> _traders = new List<Trader>();

        public Market()
        {
            for (var idx = 0; idx < Settings.Default.TraderNumber; idx++)
            {
                _traders.Add(new Trader(new AltruistStategy()));
                _traders.Add(new Trader(new CheaterStategy()));
                _traders.Add(new Trader(new MimicStrategy()));
                _traders.Add(new Trader(new RandomStrategy()));
                _traders.Add(new Trader(new OffensiveStrategy()));
                _traders.Add(new Trader(new FiveCounterStrategy()));
               // _traders.Add(new Trader(new myStrategy()));
            }
        }

        public void NextYear()
        {
            var shuffle = new List<Tuple<Trader, Trader, int>>(); 

            for (var i = 0; i < _traders.Count - 1; i++)
            {
                for (var j = i + 1; j < _traders.Count; j++)
                {
                    var a = _traders[i];
                    var b = _traders[j];
                    var count = Strategy.Random.Next(5, 10);
                    shuffle.Add(Tuple.Create(a, b, count));
                }
            }            
            
            foreach (var pair in shuffle)
            {
                for (var countDeal = pair.Item3; countDeal >= 0; --countDeal)
                {
                    pair.Item1.Deal(pair.Item2);
                    pair.Item2.Deal(pair.Item1);
                }
            }

            //Console.WriteLine(_traders.Count());
            //Console.WriteLine(shuffle.Count());          
            
            var dictionary = new Dictionary<Type, string>
            {
                [typeof(AltruistStategy)] = "Альтруист",
                [typeof(CheaterStategy)] = "Обманщик",
                [typeof(FiveCounterStrategy)] = "Пятёрочник",
                [typeof(MimicStrategy)] = "Хитрец",
                [typeof(OffensiveStrategy)] = "Обидчивый",
                [typeof(RandomStrategy)] = "Непредсказуемый",
                [typeof(myStrategy)] = "моя"
            };
            
            Console.WriteLine("Торговцы: ");
            var groups = _traders.GroupBy(_ => _.Strategy.GetType());
            
            foreach (var group in groups)
            {

                Console.WriteLine($" {dictionary[group.Key]}, кол-во: {group.Count()}");
            }
                
            _traders.Sort((a, b) => b.Income.CompareTo(a.Income));

            for (var i = 0; i < _traders.Count * Settings.Default.TraderPercentToKillOff; ++i)
            {
                _traders[_traders.Count - i - 1] = _traders[i].Clone();
            }

            foreach (var a in _traders)
           {
               a.NextYear();
            }
            /*
            foreach (var trader in _traders.OrderByDescending(_ => _.Money))
            {
                Console.WriteLine(trader.Money + ": " + trader.Strategy.GetType().Name);
            }
            */
        }

        public IEnumerator<Trader> GetEnumerator() => _traders.Cast<Trader>().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}


