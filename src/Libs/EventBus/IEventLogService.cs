using System.Collections.Generic;
using System.Threading.Tasks;

namespace Libs.EventBus
{
    public interface IEventLogService
    {
        Task<IEnumerable<EventLog>> RetrievePendingEventAsync();

        Task SaveAsync(IEvent @event);

        Task MarkAsInProgressAsync(string id);

        Task MarkAsPublishedAsync(string id);

        Task MarkAsFailedAsync(string id);
    }
}
