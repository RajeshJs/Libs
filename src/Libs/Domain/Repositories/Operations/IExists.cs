using Libs.Domain.Entities;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Libs.Domain.Repositories.Operations
{
    public interface IExists<TEntity, in TPrimaryKey> 
        where TEntity : IEntity<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        bool Any(TPrimaryKey id);

        bool Any(Expression<Func<TEntity, bool>> predicate);
    }

    public interface IExistsAsync<TEntity, in TPrimaryKey>
        where TEntity : IEntity<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        Task<bool> AnyAsync(TPrimaryKey id, CancellationToken cancellationToken = default);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
