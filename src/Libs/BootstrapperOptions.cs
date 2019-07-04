using Libs.Dependency;

namespace Libs
{
    public class BootstrapperOptions
    {
        public IIocManager IocManager { get; set; }

        public BootstrapperOptions()
        {
            IocManager = Dependency.IocManager.Instance;
        }
    }
}
