using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using APIWoood.Logic.SharedKernel.Interfaces;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Repositories
{
    public class DebtorOrderRepository : IRepository<DebtorOrder, int>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DebtorOrder GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(DebtorOrder entity)
        {
            throw new NotImplementedException();
        }

        public PagedResult<DebtorOrder> List(string sortOrder, int pageSize = 25, int pageNumber = 1)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var criteria = session.CreateCriteria<DebtorOrder>();

                switch (sortOrder)
                {
                    case "DEBITEURNR_ASC":
                    default:
                        criteria.AddOrder(new Order("DEBNR", true));
                        criteria.AddOrder(new Order("ORDERNR", true));
                        break;
                }

                var countCriteria = CriteriaTransformer.TransformToRowCount(criteria);

                criteria.SetMaxResults(pageSize)
                    .SetFirstResult((pageNumber - 1) * pageSize);

                var multi = session.CreateMultiCriteria()
                    .Add(countCriteria)
                    .Add(criteria)
                    .List();

                var result = new PagedResult<DebtorOrder>();

                result.CurrentPage = pageNumber;

                result.PageSize = pageSize;

                result.RowCount = (int)((IList)multi[0])[0];
                var pageCount = (double)result.RowCount / result.PageSize;

                result.PageCount = (int)Math.Ceiling(pageCount);

                result.Results = ((IEnumerable)multi[1]).Cast<DebtorOrder>().ToList();

                return result;
            }

        }

        public PagedResult<DebtorOrder> ListByDebtor(string debiteurnr, int pageSize = 25, int pageNumber = 1)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var criteria = session.CreateCriteria<DebtorOrder>();

                criteria.AddOrder(new Order("ORDERNR", true));
                criteria.Add(Expression.Eq("DEBNR", debiteurnr));
 
                var countCriteria = CriteriaTransformer.TransformToRowCount(criteria);

                criteria.SetMaxResults(pageSize)
                    .SetFirstResult((pageNumber - 1) * pageSize);

                var multi = session.CreateMultiCriteria()
                    .Add(countCriteria)
                    .Add(criteria)
                    .List();

                var result = new PagedResult<DebtorOrder>();

                result.CurrentPage = pageNumber;

                result.PageSize = pageSize;

                result.RowCount = (int)((IList)multi[0])[0];
                var pageCount = (double)result.RowCount / result.PageSize;

                result.PageCount = (int)Math.Ceiling(pageCount);

                result.Results = ((IEnumerable)multi[1]).Cast<DebtorOrder>().ToList();

                return result;
            }
        }

        public IEnumerable<DebtorOrder> ListByDebtor(string debiteurnr)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = from d in session.Query<DebtorOrder>()
                            select d;

                query = query.OrderBy(d => d.ORDERNR);
                query = query.Where(x => x.DEBNR == debiteurnr);

                return query.ToList();
            }
        }

        public IEnumerable<DebtorOrder> List()
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = from d in session.Query<DebtorOrder>()
                            select d;

                query = query.OrderBy(d => d.DEBNR);
                query = query.OrderBy(d => d.ORDERNR);

                return query.ToList();
            }
        }

        public void Update(DebtorOrder entity)
        {
            throw new NotImplementedException();
        }
    }
}
