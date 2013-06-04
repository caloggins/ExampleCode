namespace NhibSamples.UnitTests
{
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Dialect;
    using NHibernate.Driver;
    using NHibernate.Mapping.ByCode;
    using NHibernate.Tool.hbm2ddl;
    using NhibSamples.ConsoleApp.DataAccess;

    public abstract class DatabaseContext
    {
        private const string ConnectionString = "Data Source=:memory:;Version=3;New=True;";
        public TestContext TestContext { get; set; }
        public ISessionFactory ContextSessionFactory { get; set; }
        protected ISession ContextSession { get; set; }

        [TestInitialize]
        public void TestInitizlize()
        {
            var config = new Configuration();

            config.DataBaseIntegration(
                db =>
                {
                    db.Dialect<SQLiteDialect>();
                    db.Driver<SQLite20Driver>();
                    db.ConnectionString = ConnectionString;
                    db.LogSqlInConsole = false;
                    db.LogFormattedSql = true;
                    db.AutoCommentSql = true;
                }
                );
            config.SetProperty(Environment.CurrentSessionContextClass, "thread_static");

            var mapper = new ModelMapper();
            mapper.WithMappings(config);

            ContextSessionFactory = config.BuildSessionFactory();
            
            ContextSession = ContextSessionFactory.OpenSession();

            var schemaExport = new SchemaExport(config);
            schemaExport.Execute(false, true, false, ContextSession.Connection, TextWriter.Null);

            Context();
            BecauseOf();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Cleanup();
        }

        protected virtual void Context()
        {

        }

        protected virtual void BecauseOf()
        {

        }

        protected virtual void Cleanup()
        {

        }
    }
}