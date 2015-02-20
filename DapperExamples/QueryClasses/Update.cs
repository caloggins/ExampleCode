namespace QueryClasses
{
    using System.Data;
    using DapperExtensions;

    public class Update<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        private readonly IDbConnection connection;

        public Update(IDbConnection connection)
        {
            this.connection = connection;
        }

        public void Run(TEntity thingToUpdate)
        {
            using (var transaction = connection.BeginTransaction())
            {
                var deleted = connection.Delete<TEntity>(new { thingToUpdate.Id }, transaction);

                if (deleted)
                    connection.Insert(thingToUpdate, transaction);

                transaction.Commit();
            }
        }
    }
}