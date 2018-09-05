using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class DeliveryMethod
    {
        public virtual string CODE { get; set; }
        public virtual string NL_DESC { get; set; }
        public virtual string EN_DESC { get; set; }
        public virtual string DE_DESC { get; set; }
        public virtual string FR_DESC { get; set; }
    }
}
