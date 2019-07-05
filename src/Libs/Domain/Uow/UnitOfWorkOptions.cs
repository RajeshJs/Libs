using System;
using System.Transactions;

namespace Libs.Domain.Uow
{
    public class UnitOfWorkOptions
    {
        /// <summary>
        /// 事务范围选项
        /// </summary>
        public TransactionScopeOption? ScopeOption { get; set; }

        /// <summary>
        /// 是否为事务
        /// </summary>
        public bool? IsTransactional { get; set; }

        /// <summary>
        /// 事务提交超时时长
        /// </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        /// 事务隔离等级
        /// </summary>
        public IsolationLevel? IsolationLevel { get; set; }

        /// <summary>
        /// 构造，默认参数
        /// </summary>
        public UnitOfWorkOptions()
        {
            IsTransactional = false;
            Timeout = TimeSpan.FromMinutes(1);
        }
    }
}
