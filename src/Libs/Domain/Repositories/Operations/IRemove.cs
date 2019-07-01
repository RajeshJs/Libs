using Libs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Libs.Domain.Repositories.Operations
{
    public interface IRemove<TEntity, in TPrimaryKey>
        where TEntity : IEntity<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        void Remove(TPrimaryKey id);

        void Remove(TEntity entity);

        void Remove(params TPrimaryKey[] ids);

        void Remove(IEnumerable<TPrimaryKey> ids);

        void Remove(params TEntity[] entities);

        void Remove(IEnumerable<TEntity> entities);

        void Remove(Expression<Func<TEntity, bool>> predicate);
    }

    public interface IRemoveAsync<TEntity, in TPrimaryKey>
        where TEntity : IEntity<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        Task RemoveAsync(TPrimaryKey id, CancellationToken cancellationToken = default);

        Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task RemoveAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        Task RemoveAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
