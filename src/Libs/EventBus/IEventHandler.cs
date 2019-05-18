using System.Threading.Tasks;

namespace Libs.EventBus
{
    public interface IEventHandler<in TEvent>
        where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event); 
    }
}
