using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradersConsoleApp.Infrastructure;
using TradersConsoleApp.Properties;

namespace TradersConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new Market();
            for (var y = 0; y < Settings.Default.YearsToGo; ++y)
            {
                Console.WriteLine("год {0}",y+1);
                m.NextYear();
            }
/*
            foreach (var trader in m.OrderByDescending(_ => _.Money))
            {
                Console.WriteLine(trader.Money + ": " + trader.Strategy.GetType().Name);
            }
*/
        }
    }
}
