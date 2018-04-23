using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Stock
    {
        public event EventHandler<StockInfoEventArgs> StockInfo = delegate { };

        protected virtual void OnMarket(StockInfoEventArgs e)
        {
            EventHandler<StockInfoEventArgs> temp = StockInfo;
            temp?.Invoke(this, e);
        }

        public void Market()
        {
            Random rnd = new Random();
            StockInfoEventArgs sInfo = new StockInfoEventArgs();
            sInfo.USD = rnd.Next(20, 40);
            sInfo.Euro = rnd.Next(30, 50);
            OnMarket(sInfo);
        }
    }
}
