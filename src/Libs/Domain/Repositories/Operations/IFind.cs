using Libs.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Libs.Domain.Repositories.Operations
{
    public interface IFind<TEntity, in TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TEntity Find(TKey id);
    }

    public interface IFindAsync<TEntity, in TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<TEntity> FindAsync(TKey id);
    }
}
