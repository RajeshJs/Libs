using Libs.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Libs.Domain.Repositories.Operations
{
    public interface IAll<TEntity, in TPrimaryKey>
        where TEntity : IEntity<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        IQueryable<TEntity> All();

        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);
    }
}
