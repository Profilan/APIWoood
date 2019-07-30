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
    public class StructureRepository : IRepository<Structure, int>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Structure GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Structure entity)
        {
            throw new NotImplementedException();
        }



        public PagedResult<Structure> List(string sortOrder, int pageSize = 25, int pageNumber = 1)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = from s in session.Query<Structure>()
                            select s;

                switch (sortOrder)
                {
                    case "MAINPROD_ASC":
                    default:
                        query = query.OrderBy(s => s.MAINPROD);
                        break;
                }

                query = query.Where(x => x.SEQ_NO == "001")
                    .Skip((pageNumber - 1) * pageSize).Take(pageSize);

                var items = query.ToList();

                var result = new PagedResult<Structure>();
                result.CurrentPage = pageNumber;
                result.PageSize = pageSize;
                result.RowCount = GetCount();
                var pageCount = (double)result.RowCount / result.PageSize;
                result.PageCount = (int)Math.Ceiling(pageCount);
                result.Results = items;

                return result;
            }
        }

        public IEnumerable<Structure> List(string mainProd)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = from s in session.Query<Structure>()
                            select s;

                query = query.Where(s => s.MAINPROD == mainProd)
                    .OrderBy(s => s.LVL)
                    .OrderBy(s => s.SEQ_NO);
 
                return query.ToList();
            }
        }

        private int GetCount()
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = from s in session.Query<Structure>()
                            select s;

                query = query.Where(x => x.SEQ_NO == "001");

                return query.ToList().Count;
            }
        }

        public IEnumerable<Structure> ListByLevel(int level, string mainProd)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = from s in session.Query<Structure>()
                            select s;

                query = query.Where(s => s.MAINPROD == mainProd && s.LVL == level)
                    .OrderBy(s => s.SEQ_NO);

                return query.ToList();
            }
        }

        public IEnumerable<Structure> List()
        {
            throw new NotImplementedException();
        }

        public void Update(Structure entity)
        {
            throw new NotImplementedException();
        }
    }
}
