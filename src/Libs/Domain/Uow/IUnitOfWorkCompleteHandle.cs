using System;
using System.Threading.Tasks;

namespace Libs.Domain.Uow
{
    public interface IUnitOfWorkCompleteHandle : IDisposable
    {
        void Complete();

        Task CompleteAsync();
    }
}
