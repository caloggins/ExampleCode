namespace NhibSamples.ConsoleApp.DataAccess
{
    using System.Data;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Dialect;
    using NHibernate.Driver;
    using NHibernate.Mapping.ByCode;

    public class SessionFactoryFactory : ISessionFactoryFactory
    {
        public ISessionFactory CreateSessionFactory(string connectionString)
        {
            var config = new Configuration();

            config.DataBaseIntegration(
                db =>
                    {
                        db.Dialect<MsSql2008Dialect>();
                        db.Driver<Sql2008ClientDriver>();
                        db.ConnectionString = connectionString;
                        db.IsolationLevel = IsolationLevel.ReadCommitted;
                        db.LogSqlInConsole = false;
                        db.LogFormattedSql = true;
                        db.AutoCommentSql = true;
                    }
                );

            var mapper = new ModelMapper();
            mapper.WithMappings(config);

            return config.BuildSessionFactory();
        }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public static class MappingExtensions
    {
        public static void WithMappings(this ModelMapper mapper, Configuration configuration)
        {
            mapper.AddMappings(typeof(CustomerOrderMap).Assembly.GetTypes());
            configuration.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());
        }
    }
}