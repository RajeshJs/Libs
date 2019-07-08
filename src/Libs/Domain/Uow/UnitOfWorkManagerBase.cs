using System;
using System.Linq;
using System.Transactions;
using Libs.Dependency;

namespace Libs.Domain.Uow
{
    public abstract class UnitOfWorkManagerBase : IUnitOfWorkManager
    {
        private readonly IIocResolver _iocResolver;
        private readonly ICurrentUnitOfWorkProvider _currentUnitOfWorkProvider;
        private readonly IUnitOfWorkDefaultOptions _defaultOptions;

        protected UnitOfWorkManagerBase(
            IIocResolver iocResolver,
            ICurrentUnitOfWorkProvider currentUnitOfWorkProvider, 
            IUnitOfWorkDefaultOptions defaultOptions
            )
        {
            _iocResolver = iocResolver;
            _currentUnitOfWorkProvider = currentUnitOfWorkProvider;
            _defaultOptions = defaultOptions;
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
            options.FillDefaultsForNonProvidedOptions(_defaultOptions);

            var outerUow = _currentUnitOfWorkProvider.Current;

            if (options.Scope == TransactionScopeOption.Required && outerUow != null)
            {
                return new InnerUnitOfWorkCompleteHandle();
            }

            var uow = _iocResolver.Resolve<IUnitOfWork>();
            uow.OnCompleted += (sender, args) => _currentUnitOfWorkProvider.Current = null;
            uow.OnFailed += (sender, args) => _currentUnitOfWorkProvider.Current = null;
            uow.OnDisposed += (sender, args) => _iocResolver.Release(uow);

            if (outerUow != null)
            {
                options.FillOuterUowFiltersForNonProvidedOptions(outerUow.Filters.ToList());
            }

            uow.Begin(options);

            _currentUnitOfWorkProvider.Current = uow;

            return uow;
        }
    }
}
