using APIWoood.Logic.SharedKernel;

namespace APIWoood.Logic.Models
{
    public class OrderIdentifier : ValueObject<OrderIdentifier>
    {
        public virtual string REFERENTIE { get; set; }
        public virtual string DEBITEURNR { get; set; }

        private OrderIdentifier()
        {

        }

        public OrderIdentifier(string referentie, string debiteurnr)
        {
            REFERENTIE = referentie;
            DEBITEURNR = debiteurnr;
        }

        protected override bool EqualsCore(OrderIdentifier other)
        {
            return (REFERENTIE == other.REFERENTIE && DEBITEURNR == other.DEBITEURNR);
        }
    }
}
