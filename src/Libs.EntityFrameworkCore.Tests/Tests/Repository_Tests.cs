using Libs.EntityFrameworkCore.Repositories;
using Libs.EntityFrameworkCore.Tests.Domain;
using Libs.EntityFrameworkCore.Tests.Ef;
using Libs.EntityFrameworkCore.Uow;
using Shouldly;
using System;
using System.Linq;
using Xunit;
using static Libs.EntityFrameworkCore.Tests.Tests.TestExtensions;

namespace Libs.EntityFrameworkCore.Tests.Tests
{
    public class Repository_Tests
    {
        [Fact]
        public void Create_New_Blogs()
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
        public void Count_Blogs()
        {
            UseInMemoryDbContext(options =>
            {
                var repository = new EfCoreRepositoryBase<BloggingDbContext, Blog>(new BloggingDbContext(options));

                repository.Count().ShouldBe(0);
            });
        }

        [Fact]
        public void Create_New_Blogs_With_Posts()
        {
            InitializeInMemoryDbContext(options => { });
        }

        [Fact]
        public void Modify_Post()
        {
            InitializeInMemoryDbContext(options =>
            {
                using (var uowManager = new EfCoreUnitOfWorkManager())
                {
                    var repository = new PostRepository(new BloggingDbContext(options));

                    repository.Count().ShouldBe(2);

                    var uow = new EfCoreUnitOfWork(
                        ((IRepositoryWithDbContext)repository).GetDbContext()
                    );

                    uowManager.Register(uow);

                    var post = repository.All().First();

                    post.ShouldNotBeNull();

                    var postId = post.Id;

                    post.Title = "已修改";

                    repository.Modify(post);

                    uowManager.Commit();

                    repository.Single(s => s.Id.Equals(postId))
                        .Title
                        .ShouldBe("已修改");
                }
            });
        }

        [Fact]
        public void Multiple_Operations()
        {
            InitializeInMemoryDbContext(options =>
            {
                using (var uowManager = new EfCoreUnitOfWorkManager())
                {
                    var r1 = new PostRepository(new BloggingDbContext(options));
                    uowManager.Register(new EfCoreUnitOfWork(
                        ((IRepositoryWithDbContext)r1).GetDbContext()
                    ));

                    var r2 = new PostRepository(new BloggingDbContext(options));
                    uowManager.Register(new EfCoreUnitOfWork(
                        ((IRepositoryWithDbContext)r2).GetDbContext()
                    ));

                    var r3 = new EfCoreRepositoryBase<BloggingDbContext, Comment>(new BloggingDbContext(options));
                    uowManager.Register(new EfCoreUnitOfWork(
                        ((IRepositoryWithDbContext)r3).GetDbContext()
                    ));

                    var p1 = new Post
                    {
                        Title = "r1 新增 Post"
                    };
                    r1.Create(p1);

                    var p2 = r2.All().First();
                    p2.Title = "r2 修改 Post";
                    r2.Modify(p2);

                    var c3Id = r3.All().First().Id;
                    r3.Remove(c3Id);

                    uowManager.Commit();

                    var r4 = new PostRepository(new BloggingDbContext(options));

                    r4.All().Count().ShouldBe(3);
                    r4.Single(s => s.Id.Equals(p2.Id)).Title.ShouldBe("r2 修改 Post");

                    var r5 = new EfCoreRepositoryBase<BloggingDbContext, Comment>(new BloggingDbContext(options));
                    r5.SingleOrDefault(s => s.Id == c3Id).ShouldBeNull();
                }
            });
        }
    }
}
