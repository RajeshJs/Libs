using Libs.Domain.Entities;
using System;

namespace Libs.Domain.Repositories
{
    public interface IRepository<TEntity, TKey> :
        IQueryRepository<TEntity, TKey>,
        IQueryAsyncRepository<TEntity, TKey>,
        ICommandRepository<TEntity, TKey>,
        ICommandAsyncRepository<TEntity, TKey>

        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {

    }
}
