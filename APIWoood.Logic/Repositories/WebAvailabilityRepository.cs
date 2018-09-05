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
    public class WebAvailabilityRepository : IRepository<WebAvailability, WebAvailabilityIdentifier>
    {
        public void Delete(WebAvailabilityIdentifier id)
        {
            throw new NotImplementedException();
        }

        public WebAvailability GetById(WebAvailabilityIdentifier id)
        {
            throw new NotImplementedException();
        }

        public void Insert(WebAvailability entity)
        {
            throw new NotImplementedException();
        }

        public PagedResult<WebAvailability> List(string sortOrder, int pageSize = -1, int pageNumber = -1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WebAvailability> ListByDebtor(string fakdebnr)
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = from s in session.Query<WebAvailability>()
                            select s;

                query = query.Where(s => s.WebAvailabilityIdentifier.FAKDEBNR == fakdebnr);

                return query.ToList();
            }
        }

        public IEnumerable<WebAvailability> List()
        {
            using (ISession session = SessionFactory.GetNewSession("db1"))
            {
                var query = session.Query<WebAvailability>();

                return query.ToList();
            }
        }

        public void Update(WebAvailability entity)
        {
            throw new NotImplementedException();
        }
    }
}
