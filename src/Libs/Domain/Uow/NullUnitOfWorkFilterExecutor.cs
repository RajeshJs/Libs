namespace Libs.Domain.Uow
{
    public class NullUnitOfWorkFilterExecutor: IUnitOfWorkFilterExecutor
    {
        public void ApplyDisableFilter(IUnitOfWork unitOfWork, string filterName)
        {
        }

        public void ApplyEnableFilter(IUnitOfWork unitOfWork, string filterName)
        {
        }

        public void ApplyFilterParameterValue(IUnitOfWork unitOfWork, string filterName, string parameterName, object value)
        {
        }
    }
}
