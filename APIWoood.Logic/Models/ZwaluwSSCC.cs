using APIWoood.Logic.SharedKernel;
using System;

namespace APIWoood.Logic.Models
{
    public class ZwaluwSSCC : Entity<int>
    {
        public virtual string EdiReference { get; set; }
        public virtual string ShipmentNumber { get; set; }
        public virtual DateTime DateTime { get; set; }
        public virtual string ReferenceNumber { get; set; }
        public virtual DateTime LoadingDate { get; set; }
        public virtual DateTime UnloadingDate { get; set; }
        public virtual string PrimaryReference { get; set; }
        public virtual int StatusCode { get; set; }
        public virtual string OrderNumber { get; set; }
        public virtual int OrderlineId { get; set; }
        public virtual string ItemCode { get; set; }
        public virtual decimal OrderlineQuantity { get; set; }
        public virtual string SkuCode { get; set; }
        public virtual string LotCode { get; set; }
        public virtual decimal PalletQuantity { get; set; }
        public virtual DateTime SysCreated { get; set; }
        public virtual DateTime SysModified { get; set; }
        public virtual int Status { get; set; }
        public virtual string SysMsg { get; set; }
    }
}
