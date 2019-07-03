using Libs.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Libs.Domain.Repositories.Operations
{
    public interface IWhere<TEntity, in TPrimaryKey>
        where TEntity : IEntity<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    }
}
