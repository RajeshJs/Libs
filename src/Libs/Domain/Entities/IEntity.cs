using System;

namespace Libs.Domain.Entities
{
    public interface IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey Id { get; }
    }
}
