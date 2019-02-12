using System;

namespace APIWoood.Logic.Models
{
    public class SalesOrderLineStatus
    {
        public virtual int Id { get; set; }
        public virtual string Carrier { get; set; }
        public virtual int SalesOrderLineId { get; set; }
        public virtual int OrderLineStatus { get; set; }
        public virtual DateTime TransactionDate { get; set; }
        public virtual string OrderLineStatusDescription { get; set; }
        public virtual string DeliveryData { get; set; }
    }
}
