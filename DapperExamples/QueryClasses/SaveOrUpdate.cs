namespace QueryClasses
{
    using System.Data;
    using Dapper;
    using DapperExtensions;

    internal class SaveOrUpdate<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        private readonly IDbConnection connection;

        public SaveOrUpdate(IDbConnection connection)
        {
            this.connection = connection;
        }

        public void Run(TEntity thingToSave)
        {
            using (var transaction = connection.BeginTransaction())
            {
                var updated = connection.Update(thingToSave, transaction);
                if (!updated)
                    connection.Insert(thingToSave, transaction);

                transaction.Commit();
            }
        }
    }
}