using System;
using System.Threading.Tasks;

namespace Libs.Domain.Entities.Caching
{
    public interface IEntityCache<TCacheItem, TKey>
        where TCacheItem : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TCacheItem this[TKey id] { get; }

        string CacheName { get; }

        TCacheItem Get(TKey id);

        Task<TCacheItem> GetAsync(TKey id);
    }
}
