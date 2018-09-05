using APIWoood.Logic.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Models
{
    public class WebAvailabilityIdentifier : ValueObject<WebAvailabilityIdentifier>
    {
        public virtual string FAKDEBNR { get; set; }
        public virtual string ITEMCODE { get; set; }

        protected override bool EqualsCore(WebAvailabilityIdentifier other)
        {
            return (FAKDEBNR == other.FAKDEBNR && ITEMCODE == other.ITEMCODE);
        }
    }
}
