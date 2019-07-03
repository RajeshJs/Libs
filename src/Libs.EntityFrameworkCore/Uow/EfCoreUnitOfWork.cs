using Libs.Domain.Uow;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Libs.EntityFrameworkCore.Uow
{
    public class EfCoreUnitOfWork : UnitOfWorkBase
    {
        private readonly DbContext _dbContext;

        public EfCoreUnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override void Dispose()
        {
            _dbContext.Dispose();
        }

        public override int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public override Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
