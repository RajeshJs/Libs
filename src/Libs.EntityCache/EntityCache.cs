using Libs.Caching;
using Libs.Domain.Entities;
using Libs.Domain.Entities.Caching;
using Libs.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Libs.EntityCache
{
    public class EntityCache<TEntity, TKey> :
        IEntityCache<TEntity, TKey>

        where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public string CacheName { get; }
        public ICache Cache => _cacheManager.GetCache(CacheName);

        private readonly ICacheManager _cacheManager;
        private readonly IRepository<TEntity, TKey> _repository;

        public EntityCache(
            ICacheManager cacheManager,
            IRepository<TEntity, TKey> repository,
            string cacheName = null
            )
        {
            _cacheManager = cacheManager ?? throw new ArgumentNullException(nameof(cacheManager));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            CacheName = cacheName ?? GetType().FullName;
        }

        public TEntity this[TKey id] => Get(id);

        public TEntity Get(TKey id)
        {
            return (TEntity)Cache.Get(id.ToString(), _id => _repository.Find(id));
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            var entity = await Cache.GetAsync(id.ToString(),
                async _id => await _repository.FindAsync(id));

            return (TEntity)entity;
        }
    }
}
