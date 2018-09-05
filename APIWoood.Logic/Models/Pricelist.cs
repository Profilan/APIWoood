using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class Pricelist
    {
        public virtual PricelistIdentifier PricelistIdentifier { get; set; }
        public virtual float SALESPRICE { get; set; }
        public virtual string PRIJSLIJST { get; set; }
        public virtual float KORTING { get; set; }
        public virtual int AANTAL0 { get; set; }
        public virtual float PRIJS0 { get; set; }
        public virtual int AANTAL1 { get; set; }
        public virtual float PRIJS1 { get; set; }
        public virtual int AANTAL2 { get; set; }
        public virtual float PRIJS2 { get; set; }
        public virtual int AANTAL3 { get; set; }
        public virtual float PRIJS3 { get; set; }
        public virtual int AANTAL4 { get; set; }
        public virtual float PRIJS4 { get; set; }
        public virtual int AANTAL5 { get; set; }
        public virtual float PRIJS5 { get; set; }
        public virtual int AANTAL6 { get; set; }
        public virtual float PRIJS6 { get; set; }
        public virtual int AANTAL7 { get; set; }
        public virtual float PRIJS7 { get; set; }
        public virtual int AANTAL8 { get; set; }
        public virtual float PRIJS8 { get; set; }
        public virtual int AANTAL9 { get; set; }
        public virtual float PRIJS9 { get; set; }
        public virtual int AANTAL10 { get; set; }
        public virtual float PRIJS10 { get; set; }
        public virtual string VALCODE { get; set; }
        public virtual float STANDAARD_SALESPRICE { get; set; }
        public virtual string KORTINGTYPE { get; set; }
        public virtual string PRIJSSOORT { get; set; }
    }
}
