using Libs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Libs.Domain.Repositories.Operations
{
    public interface IRemove<in TEntity, in TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        void Remove(params TKey[] ids);

        void Remove(IEnumerable<TKey> ids);

        void Remove(params TEntity[] entities);

        void Remove(IEnumerable<TEntity> entities);
    }

    public interface IRemoveAsync<in TEntity, in TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        Task RemoveAsync(TKey id, CancellationToken cancellationToken = default);

        Task RemoveAsync(IEnumerable<TKey> ids, CancellationToken cancellationToken = default);

        Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task RemoveAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}
