using Libs.EntityFrameworkCore.Repositories;
using Libs.EntityFrameworkCore.Tests.Domain;
using Libs.EntityFrameworkCore.Tests.Ef;
using Libs.EntityFrameworkCore.Uow;
using Shouldly;
using System;
using Xunit;
using static Libs.EntityFrameworkCore.Tests.Tests.TestExtensions;

namespace Libs.EntityFrameworkCore.Tests.Tests
{
    public class Repository_Tests
    {
        [Fact]
        public void Should_Create_New_Blogs()
        {
            UseInMemoryDbContext(options =>
            {
                using (var uowManager = new EfCoreUnitOfWorkManager())
                {
                    var repository = new EfCoreRepositoryBase<BloggingDbContext, Blog>(new BloggingDbContext(options));

                    var uow = new EfCoreUnitOfWork(
                        ((IRepositoryWithDbContext)repository).GetDbContext()
                    );

                    uowManager.Register(uow);

                    var blog = new Blog
                    {
                        Name = "R's blog",
                        Url = "https://www.cnblogs.com/rajesh",
                        CreationTime = DateTime.Now
                    };

                    var entity = repository.Create(blog);

                    uowManager.Commit();

                    entity.Id.ShouldBeGreaterThan(0);
                }
            });
        }

        [Fact]
        public void Should_Count_Blogs()
        {
            UseInMemoryDbContext(options =>
            {
                var repository = new EfCoreRepositoryBase<BloggingDbContext, Blog>(new BloggingDbContext(options));

                repository.Count().ShouldBe(0);
            });
        }
    }
}
