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
    public class UserDebtorRepository : IRepository<UserDebtor, string>
    {
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public UserDebtor GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(UserDebtor entity)
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

        public PagedResult<UserDebtor> List(string sortOrder, int pageSize = -1, int pageNumber = -1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDebtor> List()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDebtor> ListByUserId(int userId)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var query = from u in session.Query<UserDebtor>()
                            select u;

                query = query.Where(u => u.UserDebtorIdentifier.USER_ID == userId);

                return query.ToList();
            }
        }

        public void Update(UserDebtor entity)
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
