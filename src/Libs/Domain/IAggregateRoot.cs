using System;

namespace Libs.Domain
{
    public interface IAggregateRoot<TPrimaryKey>
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {

    }
}
