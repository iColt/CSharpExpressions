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
                    db.ConnectionString=@"";
                    db.Dialect<MsSql2008Dialect>();
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
