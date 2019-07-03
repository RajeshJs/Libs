using Libs.EntityFrameworkCore.Repositories;
using Libs.EntityFrameworkCore.Tests.Domain;
using System;

namespace Libs.EntityFrameworkCore.Tests.Ef
{
    public class PostRepository : EfCoreRepositoryBase<BloggingDbContext, Post, Guid>, IPostRepository
    {
        public PostRepository(BloggingDbContext context) : base(context)
        {

        }
    }
}
