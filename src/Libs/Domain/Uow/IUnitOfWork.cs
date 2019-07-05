using System;

namespace Libs.Domain.Uow
{
    public interface IUnitOfWork : IActiveUnitOfWork, IUnitOfWorkCompleteHandle
    {
        string Id { get; }

        IUnitOfWork Outer { get; }

        void Begin(UnitOfWorkOptions options);
    }
}
