using Libs.Dependency;
using Libs.Tests.Services;
using Shouldly;
using Xunit;

namespace Libs.Tests.Dependency
{
    public class IocManager_Tests
    {
        private readonly IIocManager _iocManager;

        public IocManager_Tests()
        {
            _iocManager = new IocManager();

            _iocManager.Register<IService, Service>();
        }

        [Fact]
        public void Resolve_Dependency()
        {
            _iocManager.Resolve<IService>().Get().ShouldBe(1);
        }
    }
}
