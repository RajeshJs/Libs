using System;

namespace Libs.Domain.Entities
{
    public interface IId<out T> where T : IEquatable<T>
    {
        T Id { get; }
    }
}
