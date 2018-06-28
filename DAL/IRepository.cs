using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL
{
    public interface IRepository : IDisposable
    {
        TEntity Create<TEntity>(TEntity toCreate) where TEntity : class;
        bool Delete<TEntity>(TEntity toDelete) where TEntity : class;
        bool Update<TEntity>(TEntity toUpdate) where TEntity : class;
        TEntity Get<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
        List<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> criteria) where TEntity : class;
    }
}
