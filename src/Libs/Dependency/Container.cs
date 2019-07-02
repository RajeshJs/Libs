using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Libs.Dependency
{
    /// <summary>
    /// Autofac对象容器
    /// </summary>
    internal class Container : IContainer
    {
        /// <summary>
        /// 容器
        /// </summary>
        private Autofac.IContainer _container;

        /// <summary>
        /// 创建集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">服务名称</param>
        public List<T> CreateList<T>(string name = null)
        {
            var result = CreateList(typeof(T), name);
            if (result == null)
                return new List<T>();
            return ((IEnumerable<T>)result).ToList();
        }

        /// <summary>
        /// 创建集合
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="name">服务名称</param>
        public object CreateList(Type type, string name = null)
        {
            Type serviceType = typeof(IEnumerable<>).MakeGenericType(type);
            return Create(serviceType, name);
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">服务名称</param>
        public T Create<T>(string name = null)
        {
            return (T)Create(typeof(T), name);
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="name">服务名称</param>
        public object Create(Type type, string name = null)
        {
            return GetService(type, name);
        }

        /// <summary>
        /// 获取服务
        /// </summary>
        private object GetService(Type type, string name = null)
        {
            if (name == null)
                return _container.Resolve(type);
            return _container.ResolveNamed(name, type);
        }

        /// <summary>
        /// 作用域开始
        /// </summary>
        public IScope BeginScope()
        {
            return new Scope(_container.BeginLifetimeScope());
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="modules">依赖配置</param>
        public void Register(params IModule[] modules)
        {
            Register(null, null, modules);
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="modules">依赖配置</param>
        public IServiceProvider Register(IServiceCollection services, params IModule[] modules)
        {
            return Register(services, null, modules);
        }

        /// <summary>
        /// 注册依赖
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="actionBefore">注册前操作</param>
        /// <param name="modules">依赖配置</param>
        public IServiceProvider Register(IServiceCollection services, Action<ContainerBuilder> actionBefore, params IModule[] modules)
        {
            var builder = CreateBuilder(services, actionBefore, modules);
            _container = builder.Build();
            return new AutofacServiceProvider(_container);
        }

        /// <summary>
        /// 创建容器生成器
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <param name="actionBefore">注册前执行的操作</param>
        /// <param name="modules">依赖配置</param>
        public ContainerBuilder CreateBuilder(IServiceCollection services, Action<ContainerBuilder> actionBefore, params IModule[] modules)
        {
            var builder = new ContainerBuilder();
            actionBefore?.Invoke(builder);
            if (modules != null)
            {
                foreach (var config in modules)
                    builder.RegisterModule(config);
            }
            if (services != null)
                builder.Populate(services);
            return builder;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            _container.Dispose();
        }
    }
}