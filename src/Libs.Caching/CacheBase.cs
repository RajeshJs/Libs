using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Libs.Caching
{
    public abstract class CacheBase : ICache
    {
        public string Name => throw new NotImplementedException();

        public TimeSpan SlidingExpireTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public TimeSpan? AbsoluteExpireTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public Task ClearAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public object Get(string key, Func<string, object> factory)
        {
            throw new NotImplementedException();
        }

        public object[] Get(string[] keys, Func<string, object> factory)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetAsync(string key, Func<string, Task<object>> factory)
        {
            throw new NotImplementedException();
        }

        public Task<object[]> GetAsync(string[] keys, Func<string, Task<object>> factory)
        {
            throw new NotImplementedException();
        }

        public object GetOrDefault(string key)
        {
            throw new NotImplementedException();
        }

        public object[] GetOrDefault(string[] keys)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetOrDefaultAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<object[]> GetOrDefaultAsync(string[] keys)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string[] keys)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string[] keys)
        {
            throw new NotImplementedException();
        }

        public void Set(string key, object value, TimeSpan? slidingExpireTime = null, TimeSpan? absoluteExpireTime = null)
        {
            throw new NotImplementedException();
        }

        public void Set(KeyValuePair<string, object>[] pairs, TimeSpan? slidingExpireTime = null, TimeSpan? absoluteExpireTime = null)
        {
            throw new NotImplementedException();
        }

        public Task SetAsync(string key, object value, TimeSpan? slidingExpireTime = null, TimeSpan? absoluteExpireTime = null)
        {
            throw new NotImplementedException();
        }

        public Task SetAsync(KeyValuePair<string, object>[] pairs, TimeSpan? slidingExpireTime = null, TimeSpan? absoluteExpireTime = null)
        {
            throw new NotImplementedException();
        }
    }
}
