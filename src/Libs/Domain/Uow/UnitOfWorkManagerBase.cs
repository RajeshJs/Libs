using System;
using Libs.Dependency;

namespace Libs.Domain.Uow
{
    public abstract class UnitOfWorkManagerBase : IUnitOfWorkManager
    {
        private readonly IIocResolver _iocResolver;
        private readonly ICurrentUnitOfWorkProvider _currentUnitOfWorkProvider;

        protected UnitOfWorkManagerBase(
            IIocResolver iocResolver,
            ICurrentUnitOfWorkProvider currentUnitOfWorkProvider
            )
        {
            _iocResolver = iocResolver;
            _currentUnitOfWorkProvider = currentUnitOfWorkProvider;
        }

        /// <inheritdoc />
        public IActiveUnitOfWork Current => _currentUnitOfWorkProvider.Current;

        /// <inheritdoc />
        public IUnitOfWorkCompleteHandle Begin()
        {
            return Begin(new UnitOfWorkOptions());
        }

        /// <inheritdoc />
        public IUnitOfWorkCompleteHandle Begin(UnitOfWorkOptions options)
        {
            var outerUow = _currentUnitOfWorkProvider.Current;


        }
    }
}
