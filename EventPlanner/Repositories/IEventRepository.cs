using EventPlanner.Models;

namespace EventPlanner.Repositories
{
    public interface IEventRepository
    {
        Task<Event> CreateEvent(Event _event);
        IEnumerable<Event> GetAllEvents();
        Task<Event> GetEvent(int id);
        Task<Event> UpdateEvent(Event _event);
        Task DeleteEvent(int id);
    }
}
