using EventPlanner.Data;
using EventPlanner.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlanner.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Event> CreateEvent(Event _event)
        {
            _event.Id = 0;
            _context.Events.Add(_event);
            await _context.SaveChangesAsync();
            return _event;
        }

        public async Task DeleteEvent(int id)
        {
            var eventToDelete = await _context.Events.FindAsync(id);
            if(eventToDelete != null)
            {
                _context.Events.Remove(eventToDelete);
            }
            else
            {
                throw new ArgumentNullException();

            }
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _context.Events.ToList();
        }

        public async Task<Event> GetEvent(int id)
        {
           return await _context.Events.FindAsync(id) ?? throw new ArgumentNullException();
        }

        public async Task<Event> UpdateEvent(Event _event)
        { 
            _context.Entry(_event).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _event;
        }
    }
}
