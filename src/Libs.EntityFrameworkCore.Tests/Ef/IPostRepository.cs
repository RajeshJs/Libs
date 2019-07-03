using Libs.Domain.Repositories;
using Libs.EntityFrameworkCore.Tests.Domain;
using System;

namespace Libs.EntityFrameworkCore.Tests.Ef
{
    public interface IPostRepository : IRepository<Post, Guid>
    {

    }
}
