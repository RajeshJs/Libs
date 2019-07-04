using System;
using Castle.Core.Logging;
using Castle.MicroKernel.Registration;
using Libs.Dependency;

namespace Libs
{
    public class Bootstrapper : IDisposable
    {
        public IIocManager IocManager { get; internal set; }

        private ILogger _logger;

        private Bootstrapper(Action<BootstrapperOptions> optionsAction)
        {
            var options = new BootstrapperOptions();
            optionsAction?.Invoke(options);

            _logger = NullLogger.Instance;

            IocManager = options.IocManager;
        }

        /// <summary>
        /// 创建引导器
        /// </summary>
        /// <param name="optionsAction">引导器配置方法</param>
        /// <returns></returns>
        public static Bootstrapper Create(Action<BootstrapperOptions> optionsAction)
        {
            return new Bootstrapper(optionsAction);
        }

        /// <summary>
        /// 引导器初始化
        /// </summary>
        public virtual void Initialize()
        {
            ResolveLogger();

            try
            {
                RegisterBootstrapper();

                IocManager.AddConventionalRegistrar(new BasicConventionalDependencyRegistrar());
            }
            catch (Exception e)
            {
                _logger.Fatal(e.ToString(), e);
                throw;
            }
        }

        private void ResolveLogger()
        {
            if (IocManager.IsRegistered<ILoggerFactory>())
            {
                _logger = IocManager.Resolve<ILoggerFactory>().Create(typeof(Bootstrapper));
            }
        }

        private void RegisterBootstrapper()
        {
            if (!IocManager.IsRegistered<Bootstrapper>())
            {
                IocManager.IocContainer.Register(
                    Component.For<Bootstrapper>().Instance(this)
                );
            }
        }

        /// <summary>
        /// 释放 Ioc 管理器
        /// </summary>
        public void Dispose()
        {
            IocManager?.Dispose();
        }
    }
}
