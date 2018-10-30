using APIWoood.Logic.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using System.Data.SqlClient;
using NHibernate.Transform;

namespace APIWoood.Logic.Helpers
{
    public class HibernateStoredProcedureExecutor : IExecuteStoredProcedure
    {
        private readonly ISession _session;

        public HibernateStoredProcedureExecutor(ISession session)
        {
            _session = session;
        }

        public static IQuery AddStoredProcedureParameters(IQuery query, IEnumerable<SqlParameter> parameters)
        {
            foreach (var parameter in parameters)
            {
                query.SetParameter(parameter.ParameterName, parameter.Value);
            }

            return query;
        }

        public TOut ExecuteScalarStoredProcedure<TOut>(string procedureName, IList<SqlParameter> sqlParameters)
        {
            TOut result;

            var query = _session.GetNamedQuery(procedureName);
            AddStoredProcedureParameters(query, sqlParameters);
            result = query.SetResultTransformer(Transformers.AliasToBean(typeof(TOut))).UniqueResult<TOut>();

            return result;
        }

        public IEnumerable<TOut> ExecuteStoredProcedure<TOut>(string procedureName, IList<SqlParameter> sqlParameters)
        {
            IEnumerable<TOut> result;

            var query = _session.GetNamedQuery(procedureName);
            AddStoredProcedureParameters(query, sqlParameters);
            result = query.List<TOut>();

            return result;
        }

        public IEnumerable<TOut> ExecuteStoredProcedure<TOut>(string procedureName)
        {
            IEnumerable<TOut> result;

            var query = _session.GetNamedQuery(procedureName);
            
            result = query.List<TOut>();

            return result;
        }
    }
}
