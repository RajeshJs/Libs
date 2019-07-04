using System.Reflection;

namespace Libs.Dependency
{
    /// <inheritdoc />
    internal class ConventionalRegistrationContext : IConventionalRegistrationContext
    {
        /// <inheritdoc />
        public Assembly Assembly { get; set; }

        /// <inheritdoc />
        public IIocManager IocManager { get; set; }

        /// <inheritdoc />
        public ConventionalRegistrationConfig Config { get; set; }

        internal ConventionalRegistrationContext(
            Assembly assembly,
            IocManager iocManager,
            ConventionalRegistrationConfig config
            )
        {
            Assembly = assembly;
            IocManager = iocManager;
            Config = config;
        }
    }
}
