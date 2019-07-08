using System;

namespace Libs.Domain.Uow
{
    public class UnitOfWorkFailedEventArgs: EventArgs
    {
        public Exception Exception { get; }

        public UnitOfWorkFailedEventArgs(Exception exception)
        {
            Exception = exception;
        }
    }
}
