using Castle.Windsor;
using System;

namespace Libs.Dependency
{
    /// <summary>
    /// Ioc 管理器
    /// </summary>
    public interface IIocManager : IIocRegistrar, IIocResolver, IDisposable
    {
        /// <summary>
        /// Castle Windsor 依赖注入容器
        /// </summary>
        IWindsorContainer IocContainer { get; }

        /// <summary>
        /// 检查给定类型是否已注册
        /// </summary>
        /// <param name="type">需要检测的类型</param>
        new bool IsRegistered(Type type);

        /// <summary>
        /// 检查给定类型是否已注册
        /// </summary>
        /// <typeparam name="T">需要检测的类型</typeparam>
        new bool IsRegistered<T>();
    }
}
