using Libs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Libs.Domain.Repositories.Operations
{
    public interface IAdd<in TEntity, in TKey> 
        where TEntity : IEntity<TKey>
        where TKey: IEquatable<TKey>
    {
        void Add(params TEntity[] entities);

        void Add(IEnumerable<TEntity> entities);
    }

    public interface IAddAsync<in TEntity, in TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task AddAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}
