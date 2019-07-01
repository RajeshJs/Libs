using Libs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Libs.Domain.Repositories.Operations
{
    public interface IModify<TEntity, in TPrimaryKey>
        where TEntity : IEntity<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        TEntity Modify(TEntity entity);

        List<TEntity> Modify(params TEntity[] entities);

        List<TEntity> Modify(IEnumerable<TEntity> entities);
    }

    public interface IModifyAsync<TEntity, in TPrimaryKey>
        where TEntity : IEntity<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey> 
    {
        Task<TEntity> ModifyAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<List<TEntity>> ModifyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}
