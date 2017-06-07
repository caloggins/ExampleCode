using System.Data.Entity;

namespace GreatMovieSite.Database
{
    public class MovieDatabase : DbContext
    {
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}