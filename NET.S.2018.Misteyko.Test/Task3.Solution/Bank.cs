using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Bank
    {
        public string Name { get; set; }

        public Bank(string name)
        {
            this.Name = name;
        }

        public void Update(object sender, StockInfoEventArgs e)
        {
            StockInfoEventArgs sInfo = e;

            if (sInfo.Euro > 40)
                Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, sInfo.Euro);
            else
                Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, sInfo.Euro);
        }

        public void Register(Stock stock)
        {
            stock.StockInfo += Update;
        }

        public void StopTrade(Stock stock)
        {
            stock.StockInfo -= Update;
        }
    }
}
