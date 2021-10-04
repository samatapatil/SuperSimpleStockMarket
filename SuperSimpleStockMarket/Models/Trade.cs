using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSimpleStockMarket.Models
{
   public class Trade
    {
        DateTime timestamp;
        Int64 quantityofshares;
        string indicator;
        double tradedprice;
        public Trade( DateTime dateTime, Int64 qs, string indi, double tradeprices)
        {
            Timestamp = dateTime;
            Quantityofshares = qs;
            Indicator = indi;
            Tradedprice = tradeprices;
        }


        public string Indicator { get => indicator; set => indicator = value; }
        public long Quantityofshares { get => quantityofshares; set => quantityofshares = value; }
        public double Tradedprice { get => tradedprice; set => tradedprice = value; }
        public DateTime Timestamp { get => timestamp; set => timestamp = value; }
    }
}
