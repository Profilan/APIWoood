
namespace APIWoood.Logic.Models
{
    public class StockData
    {
        public virtual string ITEMCODE { get; set; }
        public virtual string EAN { get; set; }
        public virtual int STOCKLEVEL { get; set; }
        public virtual string STATUS { get; set; }
        public virtual string ATP { get; set; }
        public virtual string DFF_SHIPMENT { get; set; }

    }
}
