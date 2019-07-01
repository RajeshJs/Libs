using Libs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Libs.Domain.Repositories.Operations
{
    public interface ICreate<in TEntity, in TKey> 
        where TEntity : IEntity<TKey>
        where TKey: IEquatable<TKey>
    {
        void Create(params TEntity[] entities);

        void Create(IEnumerable<TEntity> entities);
    }

    public interface ICreateAsync<in TEntity, in TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task CreateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}
