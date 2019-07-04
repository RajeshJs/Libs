using Libs.Dependency;

namespace Libs.Tests.Services
{
    public interface ITransientService : ITransientDependency
    {
        int Counter { get; }

        void Increment();
    }

    public class TransientService : ITransientService
    {
        public int Counter { get; set; }

        public void Increment()
        {
            Counter++;
        }
    }
}
