namespace Libs.Dependency
{
    /// <summary>
    /// 依赖注入系统中类型的生命周期形式
    /// </summary>
    public enum DependencyLifeStyle
    {
        /// <summary>
        /// 单例
        /// </summary>
        Singleton,

        /// <summary>
        /// 瞬态
        /// </summary>
        Transient
    }
}
