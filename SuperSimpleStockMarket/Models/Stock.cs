using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSimpleStockMarket.Models
{
    public class Stock
    {
        private String symbol;
        //create constant
        private string type;
        private Double lastDividend;
        private Double fixedDividend;
        private Double parValue;
        private List<Trade> tradeList;
        private Double price;
        private Double divident_yeild;
        private Double peratio;
        private Double volumeWeightedStockPrice;

        public Stock(string symbol, string type, double lastDividend,
                     double fixedDividend, double parValue, 
                      List<Trade> tradeList, double price)
        {
            this.Symbol = symbol;
            this.Type = type;
            this.LastDividend = lastDividend;
            this.FixedDividend = fixedDividend;
            this.ParValue = parValue;
            this.TradeList = tradeList;
            Price = price;
        }

        public string Symbol { get => symbol; set => symbol = value; }
        public string Type { get => type; set => type = value; }
        public double LastDividend { get => lastDividend; set => lastDividend = value; }
        public double FixedDividend { get => fixedDividend; set => fixedDividend = value; }
        public double ParValue { get => parValue; set => parValue = value; }
        public List<Trade> TradeList { get => tradeList; set => tradeList = value; }
        public double Price { get => price; set => price = value; }
        public double Divident_yeild { get => divident_yeild; set => divident_yeild = value; }
        public double PEratio { get => peratio; set => peratio = value; }
        public double VolumeWeightedStockPrice { get => volumeWeightedStockPrice; set => volumeWeightedStockPrice = value; }
    }
}
