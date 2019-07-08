using System;
using System.Collections.Generic;
using System.Transactions;

namespace Libs.Domain.Uow
{
    public interface IUnitOfWorkDefaultOptions
    {
        /// <summary>
        /// 事务范围选项
        /// </summary>
        TransactionScopeOption? Scope { get; set; }

        /// <summary>
        /// 是否为事务
        /// </summary>
        bool? IsTransactional { get; set; }

        /// <summary>
        /// 事务提交超时时长
        /// </summary>
        TimeSpan? Timeout { get; set; }

        /// <summary>
        /// 事务隔离等级
        /// </summary>
        IsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        /// 指示当前应用是否存在  System.Transactions.TransactionScope
        /// </summary>
        bool IsTransactionScopeAvailable { get; set; }

        /// <summary>
        /// 按约定注册 Uow
        /// </summary>
        List<Func<Type, bool>> ConventionalUowSelectors { get; }

        IReadOnlyList<DataFilterConfiguration> Filters { get; }
    }
}
