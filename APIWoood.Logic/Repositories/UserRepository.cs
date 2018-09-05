using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using NHibernate;
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
            throw new NotImplementedException();
        }

        public override User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByUsername(string username)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var query = from u in session.Query<User>()
                            select u;

                query = query.Where(u => u.Username == username);

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
                var query = from u in session.Query<User>()
                            select u;

                return query.ToList();
            }
        }

        public override void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
