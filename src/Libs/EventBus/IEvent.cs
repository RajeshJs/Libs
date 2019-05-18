using System;
using Libs.Domain.Entities;

namespace Libs.EventBus
{
    public interface IEvent : IId<string>
    {
        EventState State { get; }

        DateTimeOffset CreateTimeStamp { get; }
    }
}
