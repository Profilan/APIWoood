using APIWoood.Logic.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class Dashboard : Entity<Int64>
    {
        public virtual string DebCode { get; set; }
        public virtual string ItemCode { get; set; }
        public virtual string EAN { get; set; }
        public virtual float Quantity { get; set; }
        public virtual float Amount { get; set; }
        public virtual string Type { get; set; }
        public virtual int AmountSortOrder { get; set; }
        public virtual int QuantitySortOrder { get; set; }
        public virtual DateTime SysModified { get; set; }
        public object Sales { get; set; }

        public Dashboard()
        {

        }
    }
}
