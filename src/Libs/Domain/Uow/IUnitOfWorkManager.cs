using System;
using Libs.Dependency;

namespace Libs.Domain.Uow
{
    /// <summary>
    /// 工作单元管理器
    /// </summary>
    public interface IUnitOfWorkManager : ITransientDependency
    {
        /// <summary>
        /// 当前活动的工作单元
        /// </summary>
        IActiveUnitOfWork Current { get; }

        /// <summary>
        /// 启动新的工作单元
        /// </summary>
        /// <returns></returns>
        IUnitOfWorkCompleteHandle Begin();

        /// <summary>
        /// 启动新的工作单元
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        IUnitOfWorkCompleteHandle Begin(UnitOfWorkOptions options);
    }
}
