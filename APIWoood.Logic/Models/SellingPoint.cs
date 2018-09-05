using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class SellingPoint
    {
        public virtual SellingPointIdentifier SellingPointIdentifier { get; set; }
        public virtual string FACTUURDEBITEURNAAM { get; set; }
        public virtual string FACTUURDEBITEUR_NAAM_ALIAS { get; set; }
        public virtual string FACTUURDEBITEURWEB { get; set; }
        public virtual string FACTUURDEBITEUR_WEB_ALIAS { get; set; }
        public virtual string FACTUURDEBITEURLAND { get; set; }
    }
}
