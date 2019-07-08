using Castle.Core;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace Libs.Domain.Uow
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        private bool _isBeginCalledBefore;
        private bool _isCompleteCalledBefore;
        private bool _succeed;
        private Exception _exception;

        public string Id { get; set; }

        [DoNotWire]
        public IUnitOfWork Outer { get; set; }

        public event EventHandler OnCompleted;
        public event EventHandler OnDisposed;
        public event EventHandler<UnitOfWorkFailedEventArgs> OnFailed;
        public UnitOfWorkOptions Options { get; set; }
        public bool IsDisposed { get; private set; }

        protected IUnitOfWorkDefaultOptions DefaultOptions { get; }
        protected IUnitOfWorkFilterExecutor FilterExecutor { get; }

        private readonly List<DataFilterConfiguration> _filters;
        public IReadOnlyList<DataFilterConfiguration> Filters => _filters.ToImmutableList();

        protected UnitOfWorkBase(
            IUnitOfWorkDefaultOptions defaultOptions,
            IUnitOfWorkFilterExecutor  filterExecutor
            )
        {
            FilterExecutor = filterExecutor;
            DefaultOptions = defaultOptions;

            Id = Guid.NewGuid().ToString("N");

            _filters = defaultOptions.Filters.ToList();
        }

        protected virtual void ApplyDisableFilter(string filterName)
        {
            FilterExecutor.ApplyDisableFilter(this, filterName);
        }

        protected virtual void ApplyEnableFilter(string filterName)
        {
            FilterExecutor.ApplyEnableFilter(this, filterName);
        }

        protected virtual void ApplyFilterParameterValue(string filterName, string parameterName, object value)
        {
            FilterExecutor.ApplyFilterParameterValue(this, filterName, parameterName, value);
        }

        /// <summary>
        /// 启动工作单元
        /// </summary>
        /// <param name="options"></param>
        public void Begin(UnitOfWorkOptions options)
        {
            PreventMultipleBegin();

            Options = options;

            BeginUow();
        }

        /// <summary>
        /// 启动工作单元
        /// </summary>
        protected abstract void BeginUow();

        /// <summary>
        /// 提交修改
        /// </summary>
        public abstract void SaveChanges();

        /// <summary>
        /// 异步提交修改
        /// </summary>
        /// <returns></returns>
        public abstract Task SaveChangesAsync();

        /// <summary>
        /// 完成工作单元
        /// </summary>
        public void Complete()
        {
            try
            {
                PreventMultipleComplete();

                CompleteUow();

                _succeed = true;

                OnCompleted?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception e)
            {
                _exception = e;
                throw;
            }
        }

        /// <summary>
        /// 完成工作单元
        /// </summary>
        public abstract void CompleteUow();

        /// <summary>
        /// 异步完成工作单元
        /// </summary>
        /// <returns></returns>
        public async Task CompleteAsync()
        {
            try
            {
                PreventMultipleComplete();

                await CompleteUowAsync();

                _succeed = true;

                OnCompleted?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception e)
            {
                _exception = e;
                throw;
            }
        }

        /// <summary>
        /// 异步完成工作单元
        /// </summary>
        /// <returns></returns>
        public abstract Task CompleteUowAsync();

        /// <summary>
        /// 释放工作单元
        /// </summary>
        protected abstract void DisposeUow();

        /// <summary>
        /// 资源释放
        /// </summary>
        public void Dispose()
        {
            if (!_isBeginCalledBefore || IsDisposed)
            {
                return;
            }

            IsDisposed = true;

            if (!_succeed)
            {
                OnFailed?.Invoke(this, new UnitOfWorkFailedEventArgs(_exception));
            }

            DisposeUow();
            OnDisposed?.Invoke(this, EventArgs.Empty);
        }

        public override string ToString()
        {
            return $"[UnitOfWork {Id}]";
        }


        /// <summary>
        /// 防止多次调用 Begin
        /// </summary>
        private void PreventMultipleBegin()
        {
            if (_isBeginCalledBefore)
            {
                throw new Exception("工作单元已启动过！");
            }
            _isBeginCalledBefore = true;
        }

        /// <summary>
        /// 防止多次调用 Complete
        /// </summary>
        private void PreventMultipleComplete()
        {
            if (_isCompleteCalledBefore)
            {
                throw new Exception("工作单元已完成过！");
            }

            _isCompleteCalledBefore = true;
        }

        private void SetFilters(List<DataFilterConfiguration> filterOverrides)
        {
            for (var i = 0; i < _filters.Count; i++)
            {
                var filterOverride = filterOverrides.FirstOrDefault(f => f.FilterName == _filters[i].FilterName);
                if (filterOverride != null)
                {
                    _filters[i] = filterOverride;
                }
            }
        }

        private void ChangeFilterIsEnabledIfNotOverride(List<DataFilterConfiguration> filterOverrides, string filterName, bool isEnabled)
        {
            if (filterOverrides.Any(f => f.FilterName == filterName))
            {
                return;
            }

            var index = _filters.FindIndex(f => f.FilterName == filterName);
            if (index < 0)
            {
                return;
            }

            if (_filters[index].IsEnabled == isEnabled)
            {
                return;
            }

            _filters[index] = new DataFilterConfiguration(filterName, isEnabled);
        }

        private DataFilterConfiguration GetFilter(string filterName)
        {
            var filter = _filters.FirstOrDefault(f => f.FilterName == filterName);
            if (filter == null)
            {
                throw new Exception("Unknown filter name: " + filterName + ". Be sure this filter is registered before.");
            }

            return filter;
        }

        private int GetFilterIndex(string filterName)
        {
            var filterIndex = _filters.FindIndex(f => f.FilterName == filterName);
            if (filterIndex < 0)
            {
                throw new Exception("Unknown filter name: " + filterName + ". Be sure this filter is registered before.");
            }

            return filterIndex;
        }
    }
}
