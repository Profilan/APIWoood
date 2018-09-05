using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class ProductRange
    {
        public virtual ProductRangeIdentifier ProductRangeIdentifier { get; set; }
        public virtual string OMSCHRIJVING { get; set; }
    }
}
