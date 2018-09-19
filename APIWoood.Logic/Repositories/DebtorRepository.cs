using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using APIWoood.Logic.SharedKernel.Interfaces;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Repositories
{
    public class DebtorRepository : IRepository<Debtor, string>
    {
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Debtor GetById(string id)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var item = session.Get<Debtor>(id);

                return item;
            }
        }

        public void Insert(Debtor entity)
        {
            throw new NotImplementedException();
        }

        public PagedResult<Debtor> List(string sortOrder, int pageSize = 25, int pageNumber = 1)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var criteria = session.CreateCriteria<Debtor>();

                switch (sortOrder)
                {
                    case "DEBITEURNR_ASC":
                    default:
                        criteria.AddOrder(new Order("DEBITEURNR", true));
                        break;
                }

                var countCriteria = CriteriaTransformer.TransformToRowCount(criteria);

                criteria.SetMaxResults(pageSize)
                    .SetFirstResult((pageNumber - 1) * pageSize);

                var multi = session.CreateMultiCriteria()
                    .Add(countCriteria)
                    .Add(criteria)
                    .List();

                var result = new PagedResult<Debtor>();

                result.CurrentPage = pageNumber;

                result.PageSize = pageSize;

                result.RowCount = (int)((IList)multi[0])[0];
                var pageCount = (double)result.RowCount / result.PageSize;

                result.PageCount = (int)Math.Ceiling(pageCount);

                result.Results = ((IEnumerable)multi[1]).Cast<Debtor>().ToList();

                return result;
            }
        }

        public IEnumerable<Debtor> List()
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = session.Query<Debtor>();

                return query.ToList();
            }
        }

        public IEnumerable<Debtor> ListById(string id)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = from d in session.Query<Debtor>()
                            select d;

                query = query.Where(d => d.DEBITEURNR == id);

                return query.ToList();
            }
        }

        public IEnumerable<Debtor> ListBySearchstring(string searchstring)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = from d in session.Query<Debtor>()
                            select d;

                query = query.Where(d => d.NAAM.Like("%" + searchstring + "%") || d.DEBITEURNR.Like("%" + searchstring + "%"));

                return query.ToList();
            }
        }

        public void Update(Debtor entity)
        {
            throw new NotImplementedException();
        }
    }
}
