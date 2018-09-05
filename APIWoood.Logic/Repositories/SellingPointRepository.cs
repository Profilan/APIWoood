using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using APIWoood.Logic.SharedKernel.Interfaces;
using NHibernate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Repositories
{
    public class SellingPointRepository : IRepository<SellingPoint, SellingPointIdentifier>
    {
        public void Delete(SellingPointIdentifier id)
        {
            throw new NotImplementedException();
        }

        public SellingPoint GetById(SellingPointIdentifier id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SellingPoint> ListByArticle(string artikelcode)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = from s in session.Query<SellingPoint>()
                            select s;

                query = query.Where(s => s.SellingPointIdentifier.ARTIKELCODE == artikelcode);

                return query.ToList();
            }
        }

        public void Insert(SellingPoint entity)
        {
            throw new NotImplementedException();
        }

        public PagedResult<SellingPoint> List(string sortOrder, int pageSize = -1, int pageNumber = -1)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var criteria = session.CreateCriteria<SellingPoint>();

                var countCriteria = CriteriaTransformer.TransformToRowCount(criteria);

                criteria.SetMaxResults(pageSize)
                    .SetFirstResult((pageNumber - 1) * pageSize);

                var multi = session.CreateMultiCriteria()
                    .Add(countCriteria)
                    .Add(criteria)
                    .List();

                var result = new PagedResult<SellingPoint>();

                result.CurrentPage = pageNumber;

                result.PageSize = pageSize;

                result.RowCount = (int)((IList)multi[0])[0];
                var pageCount = (double)result.RowCount / result.PageSize;

                result.PageCount = (int)Math.Ceiling(pageCount);

                result.Results = ((IEnumerable)multi[1]).Cast<SellingPoint>().ToList();

                return result;
            }
        }

        public IEnumerable<SellingPoint> List()
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = session.Query<SellingPoint>();

                return query.ToList();
            }
        }

        public void Update(SellingPoint entity)
        {
            throw new NotImplementedException();
        }
    }
}
