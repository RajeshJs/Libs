﻿using Libs.Caching;
using Libs.Domain.Entities;
using Libs.Domain.Entities.Caching;
using Libs.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace Libs.EntityCache
{
    public class EntityCache<TEntity, TKey> :
        IEntityCache<TEntity, TKey>

        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        private readonly ICache _cache;
        private readonly IRepository<TEntity, TKey> _repository;

        public EntityCache(
            ICache cache,
            IRepository<TEntity, TKey> repository
            )
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public TEntity this[TKey id] => Get(id);

        public string CacheName { get; }

        public TEntity Get(TKey id)
        {
            //return _cache.GetOrCreate(id,
            //    entry => _repository.Find(id));

            return null;
        }

        public Task<TEntity> GetAsync(TKey id)
        {
            //return _cache.GetOrCreateAsync(id,
            //    entry => _repository.FindAsync(id));

            return null;
        }
    }
}