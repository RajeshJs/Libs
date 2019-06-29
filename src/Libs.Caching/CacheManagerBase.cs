using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Libs.Caching
{
    public abstract class CacheManagerBase : ICacheManager
    {
        protected readonly ConcurrentDictionary<string, ICache> Caches;

        public CacheManagerBase()
        {
            Caches = new ConcurrentDictionary<string, ICache>();
        }

        public void Dispose()
        {
            DisposeCaches();

            Caches.Clear();
        }

        public IReadOnlyList<ICache> GetAllCaches()
        {
            return Caches.Values.ToImmutableList();
        }

        public ICache GetCache(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            return Caches.GetOrAdd(name, CreateCache);
        }

        protected abstract ICache CreateCache(string name);

        protected virtual void DisposeCaches()
        {
            foreach (var cache in Caches.Values)
            {
                cache.Clear();
                cache.Dispose();
            }
        }
    }
}
