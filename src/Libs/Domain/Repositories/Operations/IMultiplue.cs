using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Libs.Domain.Repositories.Operations
{
    public interface IMultiplue<out TEntity, in TKey>
        where TEntity : class
        where TKey : IEquatable<TKey>
    {
        IEnumerable<TEntity> Multiple(params TKey[] ids);

        IEnumerable<TEntity> Multiple(IEnumerable<TKey> ids);
    }

    public interface IMultiplueAsync<TEntity, in TKey>
        where TEntity : class
        where TKey : IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> MultipleAsync(IEnumerable<TKey> ids, CancellationToken cancellationToken = default);
    }
}
