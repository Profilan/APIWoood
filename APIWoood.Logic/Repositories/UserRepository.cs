using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Repositories
{
    public class UserRepository : RepositoryAbstract<User, int>
    {
        public override void Delete(int id)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var item = session.Load<User>(id);

                using (ITransaction transaction = session.BeginTransaction())
                {

                    session.Delete(item); 
                    transaction.Commit();
                }
             }
        }

        public override User GetById(int id)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var item = session.Get<User>(id);

                return item;
            }
        }

        public User GetByUsername(string username)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var query = from u in session.Query<User>()
                            select u;

                query = query.Where(u => u.UserName == username);

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

        public override void Insert(User entity)
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

        public override PagedResult<User> List(string sortOrder, int pageSize = -1, int pageNumber = -1)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<User> List()
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var query = session.Query<User>().OrderBy(x => x.UserName);
                            

                return query.ToList();
            }
        }

        public override void Update(User entity)
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
