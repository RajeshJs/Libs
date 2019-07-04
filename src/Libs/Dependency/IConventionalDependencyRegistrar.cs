namespace Libs.Dependency
{
    /// <summary>
    /// 约定注册依赖
    /// </summary>
    public interface IConventionalDependencyRegistrar
    {
        /// <summary>
        /// 按照约定注册程序集
        /// </summary>
        /// <param name="context"></param>
        void RegisterAssembly(IConventionalRegistrationContext context);
    }
}
