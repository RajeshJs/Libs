using System;
using System.Collections.Generic;
using System.Text;

namespace Libs.Domain.Entities
{
    public abstract class AggregateRoot<TPrimaryKey> : Entity<TPrimaryKey>, IAggregateRoot<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {

    }

    public abstract class AggregateRoot : AggregateRoot<int>, IEntity
    {

    }
}
