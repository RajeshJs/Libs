using Libs.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Libs.Domain.Repositories.Operations
{
    public interface IWhere<TEntity, in TPrimaryKey>
        where TEntity : IEntity<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    }

    public interface IWhereAsync<TEntity, in TPrimaryKey>
        where TEntity : IEntity<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        Task<IQueryable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default);
    }
}
