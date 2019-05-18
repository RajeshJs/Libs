﻿using System.Collections.Generic;

namespace Libs.Infrastructure.Paging
{
    public interface IPageResult<TEntity>
    {
        List<TEntity> Data { get; set; }

        int TotalCount { get; set; }

        int CurrentPage { get; set; }

        int PageSize { get; set; }

        int TotalPage { get; }
    }
}
