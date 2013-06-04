namespace NhibSamples.ConsoleApp.DataAccess
{
    using NHibernate;

    public interface ISessionFactoryFactory
    {
        ISessionFactory CreateSessionFactory(string connectionString);
    }
}