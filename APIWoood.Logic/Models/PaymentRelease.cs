using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class PaymentRelease
    {
        public virtual int ID { get; set; }
        public virtual OrderIdentifier OrderIdentifier { get; set; }
        public virtual int  PAYMENT_RELEASE { get; set; }
        public virtual int STATUS { get; set; }
        public virtual DateTime SYSCREATED { get; set; }
        public virtual DateTime SYSMODIFIED { get; set; }
        public virtual string SYSMSG { get; set; }
    }
}
