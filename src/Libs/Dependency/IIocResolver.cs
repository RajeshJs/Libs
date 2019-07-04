using System;

namespace Libs.Dependency
{
    /// <summary>
    /// 依赖注入容器的类型解析方式
    /// </summary>
    public interface IIocResolver
    {
        /// <summary>
        /// 从依赖注入容器中获取一个对象
        /// 获取的对象必须在使用后释放 <see cref="Release"/>
        /// </summary> 
        /// <typeparam name="T">需要解析的对象类型</typeparam>
        /// <returns>对象实例</returns>
        T Resolve<T>();

        /// <summary>
        /// 从依赖注入容器中获取一个对象，且转换为指定类型
        /// 获取的对象必须在使用后释放 <see cref="Release"/>
        /// </summary> 
        /// <typeparam name="T">对象需要转换为的类型</typeparam>
        /// <param name="type">需要解析的对象类型</param>
        /// <returns>对象实例</returns>
        T Resolve<T>(Type type);

        /// <summary>
        /// 从依赖注入容器中获取一个对象
        /// 获取的对象必须在使用后释放 <see cref="Release"/>
        /// </summary> 
        /// <typeparam name="T">需要解析的对象类型</typeparam>
        /// <param name="argumentsAsAnonymousType">构造参数</param>
        /// <returns>对象实例</returns>
        T Resolve<T>(object argumentsAsAnonymousType);

        /// <summary>
        /// 从依赖注入容器中获取一个对象
        /// 获取的对象必须在使用后释放 <see cref="Release"/>
        /// </summary> 
        /// <param name="type">需要解析的对象类型</param>
        /// <returns>对象实例</returns>
        object Resolve(Type type);

        /// <summary>
        /// 从依赖注入容器中获取一个对象
        /// 获取的对象必须在使用后释放 <see cref="Release"/>
        /// </summary> 
        /// <param name="type">需要解析的对象类型</param>
        /// <param name="argumentsAsAnonymousType">构造参数</param>
        /// <returns>对象实例</returns>
        object Resolve(Type type, object argumentsAsAnonymousType);

        /// <summary>
        /// 获取所有给定类型的实现类型对象
        /// 获取的对象必须在使用后释放 <see cref="Release"/>
        /// </summary> 
        /// <typeparam name="T">需要解析的对象类型</typeparam>
        /// <returns>对象实例数组</returns>
        T[] ResolveAll<T>();

        /// <summary>
        /// 获取所有给定类型的实现类型对象
        /// 获取的对象必须在使用后释放 <see cref="Release"/>
        /// </summary> 
        /// <typeparam name="T">需要解析的对象类型</typeparam>
        /// <param name="argumentsAsAnonymousType">构造参数</param>
        /// <returns>对象实例数组</returns>
        T[] ResolveAll<T>(object argumentsAsAnonymousType);

        /// <summary>
        /// 获取所有给定类型的实现类型对象
        /// 获取的对象必须在使用后释放 <see cref="Release"/>
        /// </summary> 
        /// <param name="type">需要解析的对象类型</param>
        /// <returns>对象实例数组</returns>
        object[] ResolveAll(Type type);

        /// <summary>
        /// 获取所有给定类型的实现类型对象
        /// 获取的对象必须在使用后释放 <see cref="Release"/>
        /// </summary> 
        /// <param name="type">需要解析的对象类型</param>
        /// <param name="argumentsAsAnonymousType">构造参数</param>
        /// <returns>对象实例数组</returns>
        object[] ResolveAll(Type type, object argumentsAsAnonymousType);

        /// <summary>
        /// 释放一个已解析的对象
        /// </summary>
        /// <param name="obj">将要释放的对象</param>
        void Release(object obj);

        /// <summary>
        /// 检查给定的类型是否已注册
        /// </summary>
        /// <param name="type">将要检查的类型</param>
        bool IsRegistered(Type type);

        /// <summary>
        /// 检查给定的类型是否已注册
        /// </summary>
        /// <typeparam name="T">将要检查的对象</typeparam>
        bool IsRegistered<T>();
    }
}
