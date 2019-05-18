using System;

namespace Libs.Domain.Entities
{
    public interface IEntity<out TKey> : IId<TKey>
        where TKey : IEquatable<TKey>
    {

    }
}
