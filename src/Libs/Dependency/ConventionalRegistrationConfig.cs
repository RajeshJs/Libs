using Castle.DynamicProxy;

namespace Libs.Dependency
{
    /// <summary>
    /// 约定注册配置
    /// </summary>
    public class ConventionalRegistrationConfig
    {
        /// <summary>
        /// 自动安装所有的拦截器实现 <see cref="IInterceptor"/>
        /// </summary>
        public bool InstallInstallers { get; set; }

        public ConventionalRegistrationConfig()
        {
            InstallInstallers = true;
        }
    }
}
