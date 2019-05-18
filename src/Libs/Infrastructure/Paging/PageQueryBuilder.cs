﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace Libs.Infrastructure.Paging
{
    public partial class PageQuery<TEntity>
        where TEntity : class
    {
        public class Builder
        {
            private readonly IPageQuery<TEntity> _query = null;

            public Builder()
            {
                _query = new PageQuery<TEntity>
                {
                    Predicate = s => true
                };
            }

            public Builder Filter(Expression<Func<TEntity, bool>> predicate)
            {
                var invoke = Expression.Invoke(predicate, _query.Predicate.Parameters.Cast<Expression>());

                _query.Predicate = Expression.Lambda<Func<TEntity, bool>>
                    (Expression.And(_query.Predicate.Body, invoke), _query.Predicate.Parameters);

                return this;
            }

            public Builder Filter(bool condition, Expression<Func<TEntity, bool>> predicate)
            {
                return !condition ? this : Filter(predicate);
            }

            public Builder OrderBy(string orderBy)
            {
                _query.OrderBy = orderBy;
                return this;
            }

            /// <summary>
            /// 升序
            /// </summary>
            /// <returns></returns>
            public Builder Ascending()
            {
                _query.IsDesc = false;
                return this;
            }

            /// <summary>
            /// 降序
            /// </summary>
            /// <returns></returns>
            public Builder Descending()
            {
                _query.IsDesc = true;
                return this;
            }

            public Builder SetCurrentPage(int currentPage)
            {
                _query.CurrentPage = currentPage;
                return this;
            }

            public Builder SetPageSize(int pageSize)
            {
                _query.PageSize = pageSize;
                return this;
            }

            public IPageQuery<TEntity> Build()
            {
                return _query;
            }
        }
    }
}
