using System;
using Libs.Domain.Entities;
using System.Collections.Generic;

namespace Libs.EntityFrameworkCore.Tests.Domain
{
    public class Blog : AggregateRoot
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public DateTime CreationTime { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
