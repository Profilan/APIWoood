using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIWoood.Logic.SharedKernel
{
    public class SessionFactory
    {
        private static readonly ISessionFactory _globalSessionFactory = new Configuration().Configure().BuildSessionFactory();
        private static IDictionary<string, ISessionFactory> _allFactories = LoadAllFactories();

        private static IDictionary<string, ISessionFactory> LoadAllFactories()
        {
            var dictionary = new Dictionary<string, ISessionFactory>(2);

            // Database 100 (Exact)
            var factory = new Configuration()
                .Configure()
                .SetProperty("connection.connection_string_name", "db1").BuildSessionFactory();
            dictionary.Add("db1", factory);

            // Database MAATWERK
            factory = new Configuration()
                .Configure()
                .SetProperty("connection.connection_string_name", "db2").BuildSessionFactory();
            dictionary.Add("db2", factory);

            return dictionary;
        }

        public static ISessionFactory GetSessionFactory(string identifier)
        {
            if (_allFactories == null)
            {
                _allFactories = LoadAllFactories();
            }

            return _allFactories[identifier];
        }

        public static ISession GetNewSession(string identifier)
        {
            return GetSessionFactory(identifier).OpenSession();
        }
    }
}
