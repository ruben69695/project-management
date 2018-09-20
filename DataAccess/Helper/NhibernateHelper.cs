using System;
using NHibernate;
using NHibernate.Cfg;
using Models;

namespace DataAccess.Helper
{
    public class NhibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get 
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();
                    configuration.Configure();
                    configuration.AddAssembly(typeof(Person).Assembly);
                    _sessionFactory = configuration.BuildSessionFactory();
                    new NHibernate.Tool.hbm2ddl.SchemaUpdate(configuration).Execute(false, true);
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession() {
            return SessionFactory.OpenSession();
        }
    }
}
