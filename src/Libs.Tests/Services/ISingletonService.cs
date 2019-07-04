using Libs.Dependency;

namespace Libs.Tests.Services
{
    public interface ISingletonService: ISingletonDependency
    {
        int Counter { get; }

        void Increment();
    }

    public class SingletonService : ISingletonService
    {
        public int Counter { get; private set; }

        public void Increment()
        {
            Counter++;
        }
    }
}
