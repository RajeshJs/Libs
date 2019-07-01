using Libs.Domain.Entities;
using Libs.Domain.Repositories.Operations;
using System;

namespace Libs.Domain.Repositories
{
    public interface IRepository<TEntity, TPrimaryKey> :
        IAll<TEntity, TPrimaryKey>,
        ICount<TEntity, TPrimaryKey>,
        ILongCount<TEntity, TPrimaryKey>,
        IExists<TEntity, TPrimaryKey>,
        IExistsByExpression<TEntity, TPrimaryKey>,
        IFirst<TEntity, TPrimaryKey>,
        ISingle<TEntity, TPrimaryKey>,
        IWhere<TEntity, TPrimaryKey>,
        IPaging<TEntity, TPrimaryKey>,

        IAllAsync<TEntity, TPrimaryKey>,
        ICountAsync<TEntity, TPrimaryKey>,
        ILongCountAsync<TEntity, TPrimaryKey>,
        IExistsAsync<TEntity, TPrimaryKey>,
        IExistsByExpressionAsync<TEntity, TPrimaryKey>,
        IFirstAsync<TEntity, TPrimaryKey>,
        ISingleAsync<TEntity, TPrimaryKey>,
        IWhereAsync<TEntity, TPrimaryKey>,
        IPagingAsync<TEntity, TPrimaryKey>,

        ICreate<TEntity, TPrimaryKey>,
        IModify<TEntity, TPrimaryKey>,
        IRemove<TEntity, TPrimaryKey>,

        ICreateAsync<TEntity, TPrimaryKey>,
        IModifyAsync<TEntity, TPrimaryKey>,
        IRemoveAsync<TEntity, TPrimaryKey>

        where TEntity : IEntity<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {

    }

    public interface IRepository<TEntity> : IRepository<TEntity, int>
        where TEntity : IEntity<int>
    {

    }
}
