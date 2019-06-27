using Libs.Domain.Entities;
using System;

namespace Libs.Domain.Repositories.Operations
{
    public interface IPaging<TEntity, in TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        // IPageResult<TEntity> Paging(IPageQuery<TEntity> query);
    }
     
    public interface IPagingAsync<TEntity, in TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey> 
    {
        // Task<IPageResult<TEntity>> PagingAsync(IPageQuery<TEntity> query, CancellationToken cancellationToken = default);
    }
} 
