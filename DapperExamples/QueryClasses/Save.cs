namespace QueryClasses
{
    using System.Data;
    using DapperExtensions;

    public class Save<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        private readonly IDbConnection connection;

        public Save(IDbConnection connection)
        {
            this.connection = connection;
        }

        public void Run(TEntity thingToSave)
        {
            connection.Insert(thingToSave);
        }
    }
}