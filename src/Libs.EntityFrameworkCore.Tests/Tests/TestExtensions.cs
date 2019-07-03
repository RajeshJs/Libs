using Libs.EntityFrameworkCore.Repositories;
using Libs.EntityFrameworkCore.Tests.Domain;
using Libs.EntityFrameworkCore.Tests.Ef;
using Libs.EntityFrameworkCore.Uow;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;

namespace Libs.EntityFrameworkCore.Tests.Tests
{
    public static class TestExtensions
    {
        public static void InitializeInMemoryDbContext(Action<DbContextOptions<BloggingDbContext>> action)
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
                        CreationTime = DateTime.Now,
                        Posts = new List<Post>
                    {
                        new Post
                        {
                            Title = "Libs 仓储设计",
                            Summary = "",
                            Content = "",
                            Comments = new List<Comment>
                            {
                                new Comment
                                {
                                    Content = "先马后看"
                                },
                                new Comment
                                {
                                    Content = "先马后看 +1"
                                },
                            }
                        },
                        new Post
                        {
                            Title = "Libs 工作单元设计",
                            Summary = "",
                            Content = "",
                            Comments = new List<Comment>
                            {
                                new Comment
                                {
                                    Content = "先马后看"
                                },
                                new Comment
                                {
                                    Content = "先马后看 +1"
                                },
                            }
                        }
                    }
                    };

                    var entity = repository.Create(blog);

                    uowManager.Commit();

                    entity.Id.ShouldBeGreaterThan(0);

                    var postRepository = new PostRepository(new BloggingDbContext(options));
                    postRepository.Count().ShouldBe(2);

                    var commentRepository = new EfCoreRepositoryBase<BloggingDbContext, Comment>(new BloggingDbContext(options));
                    commentRepository.Count().ShouldBe(4);

                    action(options);
                }
            });
        }

        public static void UseInMemoryDbContext(Action<DbContextOptions<BloggingDbContext>> action)
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<BloggingDbContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var dbContext = new BloggingDbContext(options))
                {
                    dbContext.Database.EnsureCreated();
                }

                action(options);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
