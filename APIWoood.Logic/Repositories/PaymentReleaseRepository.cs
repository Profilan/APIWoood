using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using APIWoood.Logic.SharedKernel.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Repositories
{
    public class PaymentReleaseRepository : IRepository<PaymentRelease, int>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PaymentRelease GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentRelease> GetByIdentifier(OrderIdentifier identifier)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = from o in session.Query<PaymentRelease>()
                            select o;

                query = query.Where(o => o.OrderIdentifier == identifier);

                return query.ToList();
            }
        }

        public void Insert(PaymentRelease entity)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    entity.SYSCREATED = DateTime.Now;
                    entity.SYSMODIFIED = entity.SYSCREATED;

                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }

        public PagedResult<PaymentRelease> List(string sortOrder, int pageSize = -1, int pageNumber = -1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentRelease> List()
        {
            throw new NotImplementedException();
        }

        public void Update(PaymentRelease entity)
        {
            throw new NotImplementedException();
        }
    }
}
