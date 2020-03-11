using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace CSharpExpressions.DataAccess
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            var cfg = new Configuration().
                DataBaseIntegration(db =>
                {
                    db.ConnectionString= @"Server=SC0848;initial catalog=CSharpExpressions;Integrated Security=SSPI;";
                    db.Dialect<MsSql2005Dialect>();
                });
            var mapper = new ModelMapper();
            mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
            HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            cfg.AddMapping(mapping);
            new SchemaUpdate(cfg).Execute(true, true);
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
