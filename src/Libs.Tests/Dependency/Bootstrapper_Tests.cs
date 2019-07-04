using Libs.Dependency;
using Libs.Tests.Services;
using Shouldly;
using Xunit;

namespace Libs.Tests.Dependency
{
    public class Bootstrapper_Tests
    {
        private readonly Bootstrapper _bootstrapper;

        public Bootstrapper_Tests()
        {
            _bootstrapper = Bootstrapper.Instance;

            _bootstrapper.Initialize();

            _bootstrapper.IocManager.RegisterAssemblyByConvention(GetType().Assembly);
        }

        [Fact]
        public void Auto_Registrar_Test()
        {
            _bootstrapper.IocManager
                .Resolve<ITransientService>()
                .ShouldBeOfType<TransientService>();

            _bootstrapper.IocManager
                .Resolve<ISingletonService>()
                .ShouldBeOfType<SingletonService>();
        }

        [Fact]
        public void Transient_Singleton_Test()
        {
            var transientService = _bootstrapper.IocManager.Resolve<ITransientService>();
            var singletonService = _bootstrapper.IocManager.Resolve<ISingletonService>();

            transientService.Increment();
            transientService.Increment();
            transientService.Counter.ShouldBe(2);

            _bootstrapper.IocManager
                .Resolve<ITransientService>()
                .Counter
                .ShouldBe(0);

            singletonService.Increment();
            singletonService.Increment();
            singletonService.Counter.ShouldBe(2);

            _bootstrapper.IocManager
                .Resolve<ISingletonService>()
                .Counter
                .ShouldBe(2);
        }
    }
}
