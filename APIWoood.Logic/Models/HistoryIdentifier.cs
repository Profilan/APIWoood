using APIWoood.Logic.SharedKernel;
using System;

namespace APIWoood.Logic.Models
{
    public class HistoryIdentifier : ValueObject<HistoryIdentifier>
    {
        public virtual int UserId { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual int UrlId { get; set; }

        protected override bool EqualsCore(HistoryIdentifier other)
        {
            return (UserId == other.UserId && Date == other.Date && UrlId == other.UrlId);
        }
    }
}
