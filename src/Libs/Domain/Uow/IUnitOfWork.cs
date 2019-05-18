using System;
using System.Threading;
using System.Threading.Tasks;

namespace Libs.Domain.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();

        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
