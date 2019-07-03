using Libs.EntityFrameworkCore.Tests.Domain;
using Microsoft.EntityFrameworkCore;

namespace Libs.EntityFrameworkCore.Tests.Ef
{
    public class BloggingDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public BloggingDbContext(DbContextOptions<BloggingDbContext> options)
            : base(options)
        {

        }
    }
}
