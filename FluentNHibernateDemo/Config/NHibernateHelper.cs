using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace FluentNHibernateDemo.Config
{
    class NHibernateHelper
    {

        private static ISessionFactory sessionFactory = null;
        private static void InitializeSessionFactory()
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(db => db
                        .Server("127.0.0.1")
                        .Database("DVService")
                        .Username("sa")
                        .Password("P@ssw0rd"))
                    .ShowSql()
                    .Dialect<ParaDMMsSql2012Dialect>())
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateHelper>())
                .BuildConfiguration();
                        
            AuditEventListener.Register(configuration);

            sessionFactory = configuration.BuildSessionFactory();

            //new SchemaExport(configuration).Create(true,true);
            //exporter.Execute(true, true, false);

            new SchemaUpdate(configuration).Execute(true,  true);
        }
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                    InitializeSessionFactory();
                }
                return sessionFactory;
            }
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
