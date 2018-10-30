using System.Collections.Generic;
using System.Data.SqlClient;

namespace APIWoood.Logic.Helpers.Interfaces
{
    public interface IExecuteStoredProcedure
    {
        TOut ExecuteScalarStoredProcedure<TOut>(string procedureName, IList<SqlParameter> sqlParameters);
        IEnumerable<TOut> ExecuteStoredProcedure<TOut>(string procedureName, IList<SqlParameter> sqlParameters);
    }
}
