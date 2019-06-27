using System;
using Libs.Domain.Repositories.Operations;

namespace Libs.Domain.Repositories
{
    public interface ICommandRepository<in TEntity, in TKey> :
        IAdd<TEntity, TKey>,
        IUpdate<TEntity, TKey>,
        IDelete<TEntity, TKey>

        where TEntity : class
        where TKey : IEquatable<TKey>
    {

    }

    public interface ICommandAsyncRepository<in TEntity, in TKey> :
        IAddAsync<TEntity, TKey>,
        IUpdateAsync<TEntity, TKey>,
        IDeleteAsync<TEntity, TKey>

        where TEntity : class
        where TKey : IEquatable<TKey>
    {

    }
}
