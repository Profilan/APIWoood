using APIWoood.Logic.Helpers;
using APIWoood.Logic.Models;
using APIWoood.Logic.SharedKernel;
using APIWoood.Logic.SharedKernel.Interfaces;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.Repositories
{
    public class StockDataRepository : IRepository<StockData, string>
    {
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public StockData GetById(string id)
        {
            throw new NotImplementedException();
        }

        public StockData GetStockDataById(string id)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var executor = new HibernateStoredProcedureExecutor(session);
                var items = executor.ExecuteStoredProcedure<StockData>(
                    "GetStockDataById",
                    new[]
                    {
                        new SqlParameter("itemCode", id)
                        });

                if (items.Count() > 0)
                    return items.LastOrDefault();
                else
                    return null;
            }
        }

        public void Insert(StockData entity)
        {
            throw new NotImplementedException();
        }

        public PagedResult<StockData> List(string sortOrder, int pageSize = -1, int pageNumber = -1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockData> List()
        {
            throw new NotImplementedException();
        }

        public PagedResult<StockData> GetStockDataListByDebtor(string debtorCode, int pageSize = 25, int pageNumber = 1)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var executor = new HibernateStoredProcedureExecutor(session);
                var items = executor.ExecuteStoredProcedure<StockData>(
                    "GetStockDataListByDebtor",
                    new[]
                    {
                        new SqlParameter("debtorCode", debtorCode)
                        });

                var result = new PagedResult<StockData>();
                result.CurrentPage = pageNumber;
                result.PageSize = pageSize;
                result.RowCount = items.Count();
                var pageCount = (double)result.RowCount / result.PageSize;
                result.PageCount = (int)Math.Ceiling(pageCount);
                result.Results = items.Skip(pageSize * pageNumber).Take(pageSize).ToList();

                return result;
            }
        }

        public PagedResult<StockData> GetStockDataList(int pageSize = 25, int pageNumber = 1)
        {
            using (ISession session = SessionFactory.GetNewSession("db2"))
            {
                var executor = new HibernateStoredProcedureExecutor(session);
                var items = executor.ExecuteStoredProcedure<StockData>(
                    "GetStockDataList");

                var result = new PagedResult<StockData>();
                result.CurrentPage = pageNumber;
                result.PageSize = pageSize;
                result.RowCount = items.Count();
                Double pageCount = result.RowCount / result.PageSize;
                result.PageCount = (int)Math.Ceiling(pageCount);
                
                result.Results = items.Skip(pageSize * pageNumber).Take(pageSize).ToList();

                return result;
            }
        }

        public void Update(StockData entity)
        {
            throw new NotImplementedException();
        }
    }
}
