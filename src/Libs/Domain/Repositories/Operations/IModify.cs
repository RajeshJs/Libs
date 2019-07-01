﻿using Libs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Libs.Domain.Repositories.Operations
{
    public interface IModify<in TEntity, in TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        void Modify(params TEntity[] entities);

        void Modify(IEnumerable<TEntity> entities);
    }

    public interface IModifyAsync<in TEntity, in TKey>
        where TEntity : IEntity<TKey>
        where TKey : IEquatable<TKey> 
    {
        Task ModifyAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task ModifyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}