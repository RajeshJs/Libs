﻿using System;

namespace Libs.Domain.Repositories
{
    public interface IRepository<TEntity, TKey> :
        IQueryRepository<TEntity, TKey>,
        IQueryAsyncRepository<TEntity, TKey>,
        ICmdRepository<TEntity, TKey>,
        ICmdAsyncRepository<TEntity, TKey>

        where TEntity : class
        where TKey : IEquatable<TKey>
    {

    }
}
