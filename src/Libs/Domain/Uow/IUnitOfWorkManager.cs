using System;
using System.Threading;
using System.Threading.Tasks;
using Libs.DependencyInjection;

namespace Libs.Domain.Uow
{
    public interface IUnitOfWorkManager : IScopeDependency, IDisposable
    {
        void Commit();

        Task CommitAsync(CancellationToken cancellationToken = default);

        void Register(IUnitOfWork unitOfWork);
    }
}
