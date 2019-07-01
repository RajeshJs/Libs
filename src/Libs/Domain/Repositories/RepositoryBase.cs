using Libs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Libs.Domain.Repositories
{
    public abstract class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        public abstract IQueryable<TEntity> All();

        public virtual IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            return All();
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            return Where(predicate).Count();
        }

        public virtual long LongCount(Expression<Func<TEntity, bool>> predicate = null)
        {
            return Where(predicate).LongCount();
        }

        public virtual bool Any(TPrimaryKey id)
        {
            return All().Any(CreateEqualityExpressionForId(id));
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return All().Any(predicate);
        }

        public virtual TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return All().First(predicate);
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return All().FirstOrDefault(predicate);
        }

        public virtual TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return All().Single(predicate);
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return All().SingleOrDefault(predicate);
        }

        public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return All().Where(predicate);
        }

        public virtual Task<IQueryable<TEntity>> AllAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(All());
        }

        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate = null, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Count(predicate));
        }

        public virtual Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate = null, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(LongCount(predicate));
        }

        public virtual Task<bool> AnyAsync(TPrimaryKey id, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Any(id));
        }

        public virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Any(predicate));
        }

        public virtual Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(First(predicate));
        }

        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(FirstOrDefault(predicate));
        }

        public virtual Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Single(predicate));
        }

        public virtual Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(SingleOrDefault(predicate));
        }

        public virtual Task<IQueryable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Where(predicate));
        }

        public virtual TPrimaryKey CreateAndGetId(TEntity entity)
        {
            return Create(entity).Id;
        }

        public abstract TEntity Create(TEntity entity);

        public virtual List<TEntity> CreateMany(params TEntity[] entities)
        {
            return entities.Select(Create).ToList();
        }

        public virtual List<TEntity> CreateMany(IEnumerable<TEntity> entities)
        {
            return entities.Select(Create).ToList();
        }

        public abstract TEntity Modify(TEntity entity);

        public virtual List<TEntity> Modify(params TEntity[] entities)
        {
            return entities.Select(Modify).ToList();
        }

        public virtual List<TEntity> Modify(IEnumerable<TEntity> entities)
        {
            return entities.Select(Modify).ToList();
        }

        public abstract void Remove(TPrimaryKey id);

        public virtual void Remove(TEntity entity)
        {
            Remove(entity.Id);
        }

        public virtual void Remove(params TPrimaryKey[] ids)
        {
            ids.ToList().ForEach(Remove);
        }

        public virtual void Remove(IEnumerable<TPrimaryKey> ids)
        {
            ids.ToList().ForEach(Remove);
        }

        public virtual void Remove(params TEntity[] entities)
        {
            entities.ToList().ForEach(Remove);
        }

        public virtual void Remove(IEnumerable<TEntity> entities)
        {
            entities.ToList().ForEach(Remove);
        }

        public abstract void Remove(Expression<Func<TEntity, bool>> predicate);

        public virtual Task<TPrimaryKey> CreateAndGetIdAsync(TEntity entity)
        {
            return Task.FromResult(CreateAndGetId(entity));
        }

        public virtual Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Create(entity));
        }

        public virtual Task<List<TEntity>> CreateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(CreateMany(entities));
        }

        public virtual Task<TEntity> ModifyAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Modify(entity));
        }

        public virtual Task<List<TEntity>> ModifyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Modify(entities));
        }

        public virtual Task RemoveAsync(TPrimaryKey id, CancellationToken cancellationToken = default)
        {
            Remove(id);
            return Task.FromResult(0);
        }

        public virtual Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            Remove(entity);
            return Task.FromResult(0);
        }

        public virtual Task RemoveAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            Remove(entities);
            return Task.FromResult(0);
        }

        public virtual async Task RemoveAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            var entities = await WhereAsync(predicate, cancellationToken);

            Remove(entities);
        }

        protected virtual Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(TPrimaryKey))
            );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }
    }

    public abstract class RepositoryBase<TEntity> : RepositoryBase<TEntity, int>, IRepository<TEntity>
        where TEntity : class, IEntity
    {

    }
}
