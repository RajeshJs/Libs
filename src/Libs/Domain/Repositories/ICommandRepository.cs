using System;
using Libs.Domain.Entities;
using Libs.Domain.Repositories.Operations;

namespace Libs.Domain.Repositories
{
    public interface ICommandRepository<in TEntity, in TKey> :
        ICreate<TEntity, TKey>,
        IModify<TEntity, TKey>,
        IRemove<TEntity, TKey>

        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {

    }

    public interface ICommandAsyncRepository<in TEntity, in TKey> :
        ICreateAsync<TEntity, TKey>,
        IModifyAsync<TEntity, TKey>,
        IRemoveAsync<TEntity, TKey>

        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {

    }
}
