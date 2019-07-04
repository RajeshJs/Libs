using System.Reflection;

namespace Libs.Dependency
{
    /// <summary>
    /// 约定注册上下文
    /// </summary>
    public interface IConventionalRegistrationContext
    {
        /// <summary>
        /// 上下文程序集
        /// </summary>
        Assembly Assembly { get; }

        /// <summary>
        /// Ioc 管理器
        /// </summary>
        IIocManager IocManager { get; }

        /// <summary>
        /// 约定注册配置
        /// </summary>
        ConventionalRegistrationConfig Config { get; }
    }
}
