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
    public class UrlRepository : IRepository<Url, int>
    {
        public void Delete(int id)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var item = session.Load<Url>(id);

                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(item);
                    transaction.Commit();
                }
            }
        }

        public Url GetById(int id)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var item = session.Get<Url>(id);

                return item;
            }
        }

        public Url GetByName(string name)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var query = from u in session.Query<Url>()
                            select u;

                query = query.Where(u => u.Name == name);

                var users = query.ToList();

                if (users.Count > 0)
                {
                    return query.ToList().Last();
                }
                else
                {
                    return null;
                }
            }
        }

        public void Insert(Url entity)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }

        public PagedResult<Url> List(string sortOrder, int pageSize = -1, int pageNumber = -1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Url> List()
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var query = session.Query<Url>().OrderBy(x => x.Name);

                return query.ToList();
            }
        }

        public void Update(Url entity)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(entity);
                    transaction.Commit();
                }
            }
        }
    }
}
