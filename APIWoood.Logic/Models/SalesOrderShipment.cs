using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class SalesOrderShipment
    {
        // Id
        public virtual int Id { get; set; }
    
        // SKU_Id
        public virtual string SkuId { get; set; }
    
        // ShipmentId
        public virtual int ShipmentId { get; set; }
    
        // DebtorNumber
        public virtual string DebtorNumber { get; set; }
    
        // SKU_Type
        public virtual string SkuType { get; set;  }
    
        // Carrier
        public virtual string Carrier { get; set; }

        // DeliveryDate
        public virtual DateTime DeliveryDate { get; set; }
    
        // DebtorName
        public virtual string DebtorName { get; set; }
    
        // DelAddress
        public virtual string DelAddress { get; set; }
    
        // DelPostcode
        public virtual string DelPostcode { get; set; }
    
        // DelCity
        public virtual string DelCity { get; set; }
    
        // DelCountryCode
        public virtual string DelCountryCode { get; set; }
    
        // TrackTraceCode
        public virtual string TrackTraceCode { get; set; }
    
        // TrackTraceUrl
        public virtual string TrackTraceUrl { get; set; }
    
        // Status
        public virtual int Status { get; set; }

        public SalesOrderShipment() { }
    }
}
