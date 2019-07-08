using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Libs.Domain.Uow
{
    public interface IActiveUnitOfWork
    {
        event EventHandler OnCompleted;

        event EventHandler OnDisposed;

        event EventHandler<UnitOfWorkFailedEventArgs> OnFailed;

        IReadOnlyList<DataFilterConfiguration> Filters { get; }

        UnitOfWorkOptions Options { get; }

        void SaveChanges();

        Task SaveChangesAsync();

        bool IsDisposed { get; }
    }
}
