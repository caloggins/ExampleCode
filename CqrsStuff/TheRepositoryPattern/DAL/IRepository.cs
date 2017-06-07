using System;
using System.Collections.Generic;

namespace TheRepositoryPattern.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(Guid id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> Query(IQuery<TEntity> query);
    }
}