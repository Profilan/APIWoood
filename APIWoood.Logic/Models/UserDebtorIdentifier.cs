using APIWoood.Logic.SharedKernel;

namespace APIWoood.Logic.Models
{
    public class UserDebtorIdentifier : ValueObject<UserDebtorIdentifier>
    {
        public virtual int USER_ID { get; set; }
        public virtual string DEBITEURNR { get; set; }

        protected override bool EqualsCore(UserDebtorIdentifier other)
        {
            return (USER_ID == other.USER_ID && DEBITEURNR == other.DEBITEURNR);
        }
    }
}
