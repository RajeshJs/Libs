using System;
using System.Threading;
using System.Threading.Tasks;

namespace Libs.Domain.Uow
{
    public interface IUnitOfWorkManager : IDisposable
    {
        void Commit();

        Task CommitAsync(CancellationToken cancellationToken = default);

        void Register(IUnitOfWork unitOfWork);
    }
}
