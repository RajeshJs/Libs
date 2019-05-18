using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Libs.Domain.Repositories.Operations
{
    public interface IExists<TEntity, in TKey> 
        where TEntity : class
        where TKey : IEquatable<TKey>
    {
        bool Exists(TKey id);
    }

    public interface IExistsByExpression<TEntity, in TKey>
        where TEntity : class
        where TKey : IEquatable<TKey>
    {
        bool Exists(Expression<Func<TEntity, bool>> predicate);
    }

    public interface IExistsAsync<TEntity, in TKey>
        where TEntity : class
        where TKey : IEquatable<TKey>
    {
        Task<bool> ExistsAsync(TKey id, CancellationToken cancellationToken = default);
    }

    public interface IExistsByExpressionAsync<TEntity, in TKey>
        where TEntity : class
        where TKey : IEquatable<TKey>
    {
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
