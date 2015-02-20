namespace QueryClasses
{
    using System.Data;
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
                connection.Delete<TEntity>(new { thingToSave.Id }, transaction);
                connection.Insert(thingToSave, transaction);

                transaction.Commit();
            }
        }
    }
}