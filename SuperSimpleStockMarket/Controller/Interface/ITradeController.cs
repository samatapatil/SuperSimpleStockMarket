using SuperSimpleStockMarket.Models;
using System.Collections.Generic;

namespace SuperSimpleStockMarket.Controller.Interface
{
    public interface ITradeController
    {
        Trade AddTrade();
        string DisplayTrades(IList<Trade> trades);

    }
}