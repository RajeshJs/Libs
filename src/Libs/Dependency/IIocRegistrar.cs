using System;
using System.Reflection;

namespace Libs.Dependency
{
    /// <summary>
    /// 依赖注入容器的注册方式
    /// </summary>
    public interface IIocRegistrar
    {
        /// <summary>
        /// 添加依赖约定注册器
        /// </summary>
        /// <param name="registrar"></param>
        void AddConventionalRegistrar(IConventionalDependencyRegistrar registrar);

        /// <summary>
        /// 根据约定注册程序集
        /// </summary>
        /// <param name="assembly">需注册的程序集</param>
        void RegisterAssemblyByConvention(Assembly assembly);

        /// <summary>
        /// 根据约定注册程序集
        /// </summary>
        /// <param name="assembly">需注册的程序集</param>
        /// <param name="config">配置</param>
        void RegisterAssemblyByConvention(Assembly assembly, ConventionalRegistrationConfig config);

        /// <summary>
        /// 注册对象为自注册类型
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="lifeStyle">生命周期形式</param>
        void Register<T>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where T : class;

        /// <summary>
        /// 注册对象为自注册类型
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="lifeStyle">生命周期形式</param>
        void Register(Type type, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton);

        /// <summary>
        /// 注册类型为其实现类
        /// </summary>
        /// <typeparam name="TType">注册的类型</typeparam>
        /// <typeparam name="TImpl">实现类型 <see cref="TType"/></typeparam>
        /// <param name="lifeStyle">生命周期形式</param>
        void Register<TType, TImpl>(DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton)
            where TType : class
            where TImpl : class, TType;

        /// <summary>
        /// 注册类型为其实现类
        /// </summary>
        /// <param name="type">注册的类型</param>
        /// <param name="impl">实现类型 <paramref name="type"/></param>
        /// <param name="lifeStyle">生命周期形式</param>
        void Register(Type type, Type impl, DependencyLifeStyle lifeStyle = DependencyLifeStyle.Singleton);

        /// <summary>
        /// 检查给定类型是否已注册
        /// </summary>
        /// <param name="type">需要检查的类型</param>
        bool IsRegistered(Type type);

        /// <summary>
        /// 检查给定类型是否已注册
        /// </summary>
        /// <typeparam name="TType">需要检查的类型</typeparam>
        bool IsRegistered<TType>();
    }
}
