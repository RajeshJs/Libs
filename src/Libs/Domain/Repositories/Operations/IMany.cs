using Libs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Libs.Domain.Repositories.Operations
{
    public interface IMany<out TEntity, in TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        IEnumerable<TEntity> Many(params TKey[] ids);

        IEnumerable<TEntity> Many(IEnumerable<TKey> ids);
    }

    public interface IManyAsync<TEntity, in TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> ManyAsync(IEnumerable<TKey> ids, CancellationToken cancellationToken = default);
    }
}
