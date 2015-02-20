namespace QueryClasses
{
    using System.Data;
    using DapperExtensions;

    public class GetById<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {
        private readonly IDbConnection connection;

        public GetById(IDbConnection connection)
        {
            this.connection = connection;
        }

        public TEntity Run(object clause)
        {
            var entity = connection.Get<TEntity>(clause);
            return entity;
        }
    }
}