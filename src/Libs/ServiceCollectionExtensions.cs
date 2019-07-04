using Castle.Windsor.MsDependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Libs
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 将 Libs 集成至 asp.net core
        /// </summary>
        /// <param name="services"></param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        public static IServiceProvider AddLibs(this IServiceCollection services,
            Action<BootstrapperOptions> optionsAction)
        {
            var bootstrapper = AddBootstrapper(services, optionsAction);

            ConfigureAspNetCore(services);

            return WindsorRegistrationHelper.CreateServiceProvider(bootstrapper.IocManager.IocContainer, services);
        }

        /// <summary>
        /// 配置 asp.net core 依赖
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureAspNetCore(IServiceCollection services)
        {
            //See https://github.com/aspnet/Mvc/issues/3936 to know why we added these services.
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }

        /// <summary>
        /// 将引导器以单例注入
        /// </summary>
        /// <param name="services"></param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        private static Bootstrapper AddBootstrapper(IServiceCollection services, Action<BootstrapperOptions> optionsAction)
        {
            var bootstrapper = Bootstrapper.Create(optionsAction);
            services.AddSingleton(bootstrapper);
            return bootstrapper;
        }
    }
}
