using APIWoood.Logic.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class ProductRangeIdentifier : ValueObject<ProductRangeIdentifier>
    {
        public virtual int ASS { get; set; }
        public virtual string CODE { get; set; }

        protected override bool EqualsCore(ProductRangeIdentifier other)
        {
            return (ASS == other.ASS && CODE == other.CODE);
        }
    }
}
