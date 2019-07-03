using System;
using Libs.EntityFrameworkCore.Tests.Ef;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Libs.EntityFrameworkCore.Tests.Tests
{
    public static class TestExtensions
    {
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
