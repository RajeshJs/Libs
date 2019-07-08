namespace Libs.Domain.Uow
{
    public interface IUnitOfWorkFilterExecutor
    {
        void ApplyDisableFilter(IUnitOfWork unitOfWork, string filterName);
        void ApplyEnableFilter(IUnitOfWork unitOfWork, string filterName);
        void ApplyFilterParameterValue(IUnitOfWork unitOfWork, string filterName, string parameterName, object value);
    }
}
