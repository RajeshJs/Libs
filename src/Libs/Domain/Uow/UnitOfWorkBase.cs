using System.Threading;
using System.Threading.Tasks;

namespace Libs.Domain.Uow
{
    public abstract class UnitOfWorkBase : IUnitOfWork
    {
        public abstract void Dispose();

        public abstract int Commit();

        public virtual Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Commit());
        }
    }
}
