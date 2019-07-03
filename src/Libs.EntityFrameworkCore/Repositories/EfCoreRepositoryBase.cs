using Libs.Domain.Entities;
using Libs.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace Libs.EntityFrameworkCore.Repositories
{
    public class EfCoreRepositoryBase<TDbContext, TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey>, IRepositoryWithDbContext
        where TDbContext : DbContext
        where TEntity : class, IEntity<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        public virtual TDbContext Context { get; }
        public virtual DbSet<TEntity> Table => Context.Set<TEntity>();
        public virtual DbConnection Connection
        {
            get
            {
                var connection = Context.Database.GetDbConnection();

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                return connection;
            }
        }

        public EfCoreRepositoryBase(TDbContext context)
        {
            Context = context;
        }

        public override IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            var query = Table.AsQueryable();

            return propertySelectors == null ?
                query :
                propertySelectors.Aggregate(query, (current, selector) => current.Include(selector));
        }

        public override IQueryable<TEntity> All()
        {
            return GetAllIncluding();
        }

        public override TEntity Create(TEntity entity)
        {
            return Table.Add(entity).Entity;

        }

        public override TEntity Modify(TEntity entity)
        {
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public override void Remove(TEntity entity)
        {
            AttachIfNot(entity);
            Table.Remove(entity);
        }

        public override void Remove(TPrimaryKey id)
        {
            var entity = GetFromChangeTrackerOrNull(id);
            if (entity != null)
            {
                Remove(entity);
                return;
            }

            entity = FirstOrDefault(CreateEqualityExpressionForId(id));
            if (entity == null) return;

            Remove(entity);
        }

        public override void Remove(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = Where(predicate).ToList();

            entities.ForEach(Remove);
        }

        protected virtual void AttachIfNot(TEntity entity)
        {
            var entry = Context.ChangeTracker
                .Entries()
                .FirstOrDefault(ent => ent.Entity == entity);

            if (entry != null) return;

            Table.Attach(entity);
        }

        private TEntity GetFromChangeTrackerOrNull(TPrimaryKey id)
        {
            var entry = Context.ChangeTracker
                .Entries()
                .FirstOrDefault(
                    ent =>
                        ent.Entity is TEntity entity &&
                        EqualityComparer<TPrimaryKey>.Default.Equals(id, entity.Id)
                );

            return entry?.Entity as TEntity;
        }

        public DbContext GetDbContext()
        {
            return Context;
        }
    }

    public class EfCoreRepositoryBase<TDbContext, TEntity> : EfCoreRepositoryBase<TDbContext, TEntity, int>, IRepository<TEntity>
        where TDbContext : DbContext
        where TEntity : class, IEntity<int>
    {
        public EfCoreRepositoryBase(TDbContext context) :
            base(context)
        {

        }
    }
}
