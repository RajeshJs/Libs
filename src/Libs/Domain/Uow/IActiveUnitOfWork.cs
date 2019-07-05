using System.Threading.Tasks;

namespace Libs.Domain.Uow
{
    public interface IActiveUnitOfWork
    {
        UnitOfWorkOptions Options { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
