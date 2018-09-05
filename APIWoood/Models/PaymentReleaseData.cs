using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIWoood.Models
{
    public class PaymentReleaseData
    {
        public Header header { get; set; }
        public PaymentRelease body { get; set; }
    }
}