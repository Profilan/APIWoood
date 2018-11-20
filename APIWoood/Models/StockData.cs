using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class StockData : HalItem
    {
        public string ITEMCODE { get; set; }
        public string EAN { get; set; }
        public int STOCKLEVEL { get; set; }
        public string STATUS { get; set; }
        public StockDataAtp ATP { get; set; }
        public string DFF_SHIPMENT { get; set; }
    }
}