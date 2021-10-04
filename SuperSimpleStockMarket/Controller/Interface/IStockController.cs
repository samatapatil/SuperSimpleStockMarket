using SuperSimpleStockMarket.Models;
using System.Collections.Generic;

namespace SuperSimpleStockMarket.Controller.Interface
{
    public interface IStockController
    {
        Stock AddStock();
        public void DisplayStock(Stock stock);

        void DisplayStocks(IList<Stock> stocks);

    }
}