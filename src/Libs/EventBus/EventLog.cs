using System;
using Libs.Domain.Entities;
using Newtonsoft.Json;

namespace Libs.EventBus
{
    public class EventLog : IId<string>
    {
        public string Id { get; }
        public string TypeName { get; }
        public EventState State { get; set; }
        public DateTimeOffset CreateTimeStamp { get; }
        public int SentTimes { get; }
        public string Content { get; }

        public EventLog(IEvent @event)
        {
            Id = @event.Id;
            TypeName = @event.GetType().FullName;
            State = EventState.Pending;
            CreateTimeStamp = @event.CreateTimeStamp;
            SentTimes = 0;
            Content = JsonConvert.SerializeObject(@event);
        }
    }
}
