using SuperSimpleStockMarket.Models;
using System.Collections.Generic;

namespace SuperSimpleStockMarket.Controller.Interface
{
    public interface ICalculationController
    {
        double CalculateAllShareIndex(IList<Stock> stockList);
        double CalculateDividendYield(Stock stock);
        double CalculatePERatioPrice(double price, double dividend);
        public double VolumeWeightedStockPrice(IList<Trade> trades);
    }
}