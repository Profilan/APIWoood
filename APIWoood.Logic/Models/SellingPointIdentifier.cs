using APIWoood.Logic.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class SellingPointIdentifier : ValueObject<SellingPointIdentifier>
    {
        public virtual string ARTIKELCODE { get; set; }
        public virtual string FACTUURDEBITEURNR { get; set; }

        protected override bool EqualsCore(SellingPointIdentifier other)
        {
            return (ARTIKELCODE == other.ARTIKELCODE && FACTUURDEBITEURNR == other.FACTUURDEBITEURNR);
        }
    }
}
