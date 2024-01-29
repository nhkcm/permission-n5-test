using N5TLTest.Dtos;

namespace N5TLTest.Handlers.ports
{
    public interface IEventBrokerService
    {
        Task SendEvent(string message);
    }
}
