using Libs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Libs.Domain.Repositories.Operations
{
    public interface IDelete<in TEntity, in TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        void Delete(params TKey[] ids);

        void Delete(IEnumerable<TKey> ids);

        void Delete(params TEntity[] entities);

        void Delete(IEnumerable<TEntity> entities);
    }

    public interface IDeleteAsync<in TEntity, in TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        Task Delete(TKey id, CancellationToken cancellationToken = default);

        Task Delete(IEnumerable<TKey> ids, CancellationToken cancellationToken = default);

        Task Delete(TEntity entity, CancellationToken cancellationToken = default);

        Task Delete(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}
