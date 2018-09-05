using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class OrderLine
    {
        public virtual int ID { get; set; }
        public virtual OrderIdentifier OrderIdentifier { get; set; }
        public virtual string ITEMCODE { get; set; }
	    public virtual float AANTAL { get; set; }
	    public virtual int STATUS { get; set; }
	    public virtual string ORDERNR { get; set; }
	    public virtual string VERZENDWEEK { get; set; }
        public virtual DateTime SYSCREATED { get; set; }
        public virtual DateTime SYSMODIFIED { get; set; }
        public virtual string SYSMSG { get; set; }

        public OrderLine()
        {
            SYSCREATED = DateTime.Now;
            SYSMODIFIED = SYSCREATED;
        }
    }
}
