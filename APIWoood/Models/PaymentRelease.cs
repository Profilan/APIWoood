using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class PaymentRelease
    {
        public virtual string REFERENTIE { get; set; }
        public virtual string DEBITEURNR { get; set; }
        public virtual int PAYMENT_RELEASE { get; set; }
        public virtual int STATUS { get; set; }
        public virtual DateTime SYSCREATED { get; set; }
        public virtual DateTime SYSMODIFIED { get; set; }
        public virtual string SYSMSG { get; set; }

    }
}