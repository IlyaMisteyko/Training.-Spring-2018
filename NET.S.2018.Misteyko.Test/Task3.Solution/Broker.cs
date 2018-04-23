using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Broker
    {
        public string Name { get; set; }

        public Broker(string name)
        {
            this.Name = name;
        }

        public void Update(object sender, StockInfoEventArgs e)
        {
            StockInfoEventArgs sInfo = e;

            if (sInfo.USD > 30)
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
            else
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
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
