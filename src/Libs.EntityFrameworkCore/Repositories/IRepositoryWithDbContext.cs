using Microsoft.EntityFrameworkCore;

namespace Libs.EntityFrameworkCore.Repositories
{
    public interface IRepositoryWithDbContext
    {
        DbContext GetDbContext();
    }
}
