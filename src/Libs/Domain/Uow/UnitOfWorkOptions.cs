using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Libs.Domain.Uow
{
    public class UnitOfWorkOptions
    {
        /// <summary>
        /// 事务范围选项
        /// </summary>
        public TransactionScopeOption? Scope { get; set; }

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
        /// 过滤器
        /// </summary>
        public List<DataFilterConfiguration> FilterOverrides { get; }

        /// <summary>
        /// 构造，默认参数
        /// </summary>
        public UnitOfWorkOptions()
        {
            FilterOverrides = new List<DataFilterConfiguration>();
        }

        internal void FillDefaultsForNonProvidedOptions(IUnitOfWorkDefaultOptions defaultOptions)
        {
            if (!IsTransactional.HasValue)
            {
                IsTransactional = defaultOptions.IsTransactional;
            }

            if (!Scope.HasValue)
            {
                Scope = defaultOptions.Scope;
            }

            if (!Timeout.HasValue && defaultOptions.Timeout.HasValue)
            {
                Timeout = defaultOptions.Timeout.Value;
            }

            if (!IsolationLevel.HasValue && defaultOptions.IsolationLevel.HasValue)
            {
                IsolationLevel = defaultOptions.IsolationLevel.Value;
            }
        }

        internal void FillOuterUowFiltersForNonProvidedOptions(List<DataFilterConfiguration> filterOverrides)
        {
            foreach (var filterOverride in filterOverrides)
            {
                if (FilterOverrides.Any(fo => fo.FilterName == filterOverride.FilterName))
                {
                    continue;
                }

                FilterOverrides.Add(filterOverride);
            }
        }
    }
}
