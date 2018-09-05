using APIWoood.Logic.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class PricelistIdentifier : ValueObject<PricelistIdentifier>
    {
        public virtual string DEBITEURNR { get; set; }
        public virtual string FAKTUURDEBITEURNR { get; set; }
        public virtual string ARTIKELCODE { get; set; }

        protected override bool EqualsCore(PricelistIdentifier other)
        {
            return (DEBITEURNR == other.DEBITEURNR && FAKTUURDEBITEURNR == other.FAKTUURDEBITEURNR && ARTIKELCODE == other.ARTIKELCODE);
        }
    }
}
