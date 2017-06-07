using System.Collections.Generic;

// ReSharper disable UnusedMember.Global

namespace TheRepositoryPattern.DAL
{
    public interface IQuery<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Query(IEnumerable<TEntity> entity);
    }
}