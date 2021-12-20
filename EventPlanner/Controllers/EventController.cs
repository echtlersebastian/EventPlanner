using EventPlanner.Models;
using EventPlanner.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanner.Controllers
{
    [Authorize]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }


        [Route("api/Events/GetAllEvents")]
        [HttpGet]
        public IEnumerable<Event> GetAllEvents()
        {
            return _eventRepository.GetAllEvents();
        }

        [Route("api/Events/Details")]
        [HttpGet]
        public async Task<ActionResult<Event>> Details(int id)
        {
            return await _eventRepository.GetEvent(id);
        }

        [Route("api/Events/Create")]
        [HttpPost]
        public async Task<ActionResult<Event>> Create([FromBody] Event _event)
        {
            var newEvent = await _eventRepository.CreateEvent(_event);
            return CreatedAtAction(nameof(Event), new { id = newEvent.Id }, newEvent);
        }
        [Route("api/Events/Update")]
        [HttpPut]
        public async Task<Event> Update(Event _event)
        {
           return await _eventRepository.UpdateEvent(_event);
        } 

        [Route("api/Events/Delete")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var eventToDelete = await _eventRepository.GetEvent(id);
            if (eventToDelete == null)
                return NotFound();

            await _eventRepository.DeleteEvent(eventToDelete.Id);
            return NoContent();
        }

    }

}
