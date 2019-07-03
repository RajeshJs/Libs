using Libs.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Libs.EntityFrameworkCore.Tests.Domain
{
    public class Post : Entity<Guid>
    {
        public Blog Blog { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string Content { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
