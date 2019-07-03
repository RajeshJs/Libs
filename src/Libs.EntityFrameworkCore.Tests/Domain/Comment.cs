using Libs.Domain.Entities;

namespace Libs.EntityFrameworkCore.Tests.Domain
{
    public class Comment : Entity
    {
        public Post Post { get; set; }

        public string Content { get; set; }
    }
}
