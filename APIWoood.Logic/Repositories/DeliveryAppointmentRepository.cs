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
    public class DeliveryAppointmentRepository : IRepository<DeliveryAppointment, int>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DeliveryAppointment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(DeliveryAppointment entity)
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

        public PagedResult<DeliveryAppointment> List(string sortOrder, int pageSize = -1, int pageNumber = -1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DeliveryAppointment> List()
        {
            throw new NotImplementedException();
        }

        public void Update(DeliveryAppointment entity)
        {
            throw new NotImplementedException();
        }
    }
}
