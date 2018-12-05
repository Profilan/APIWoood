using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class DeliveryAppointment
    {
        public virtual int Id { get; set; }
        public virtual string Carrier { get; set; }
        public virtual int SalesOrderLineId { get; set; }
        public virtual int DeliveryAppointmentStatus { get; set; }
        public virtual DateTime TransactionDate { get; set; }
    }
}
