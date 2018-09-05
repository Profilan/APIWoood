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
    public class PaymentConditionRepository : IRepository<PaymentCondition, string>
    {
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public PaymentCondition GetById(string id)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var item = session.Get<PaymentCondition>(id);

                return item;
            }
        }

        public void Insert(PaymentCondition entity)
        {
            throw new NotImplementedException();
        }

        public PagedResult<PaymentCondition> List(string sortOrder, int pageSize = -1, int pageNumber = -1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentCondition> List()
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = session.Query<PaymentCondition>();

                return query.ToList();
            }
        }

        public IEnumerable<PaymentCondition> ListByCode(string code)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = from s in session.Query<PaymentCondition>()
                            select s;

                query = query.Where(s => s.CODE == code);

                return query.ToList();
            }
        }

        public void Update(PaymentCondition entity)
        {
            throw new NotImplementedException();
        }
    }
}
