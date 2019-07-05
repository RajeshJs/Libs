using Castle.Core;
using System;
using System.Threading.Tasks;

namespace Libs.Domain.Uow
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        private bool _isBeginCalledBefore = false;
        private bool _isCompleteCalledBefore = false;

        public string Id { get; set; }

        [DoNotWire]
        public IUnitOfWork Outer { get; set; }

        public UnitOfWorkOptions Options { get; set; }

        protected UnitOfWorkBase()
        {
            Id = Guid.NewGuid().ToString("N");
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
            PreventMultipleComplete();

            CompleteUow();
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
            PreventMultipleComplete();

            await CompleteUowAsync();
        }

        /// <summary>
        /// 异步完成工作单元
        /// </summary>
        /// <returns></returns>
        public abstract Task CompleteUowAsync();

        /// <summary>
        /// 资源释放
        /// </summary>
        public void Dispose()
        {
            throw new System.NotImplementedException();
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
    }
}
