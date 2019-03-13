using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTest.DbContexts;
using ApiTest.Models;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventInfosController : ControllerBase
    {
        private readonly EventDbContext _context;

        public EventInfosController(EventDbContext context)
        {
            _context = context;
        }

        // GET: api/EventInfos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventInfo>>> GetEventInfo()
        {
            //return await _context.EventInfo.ToListAsync();

            return new List<EventInfo> { new EventInfo { Id = 1, EventDate = DateTime.Now.AddMonths(1), Organiser = "Bob Smith" } };
        }

        // GET: api/EventInfos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventInfo>> GetEventInfo(int id)
        {
            var eventInfo = await _context.EventInfo.FindAsync(id);

            if (eventInfo == null)
            {
                return NotFound();
            }

            return eventInfo;
        }

        // PUT: api/EventInfos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventInfo(int id, EventInfo eventInfo)
        {
            if (id != eventInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EventInfos
        [HttpPost]
        public async Task<ActionResult<EventInfo>> PostEventInfo(EventInfo eventInfo)
        {
            _context.EventInfo.Add(eventInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventInfo", new { id = eventInfo.Id }, eventInfo);
        }

        // DELETE: api/EventInfos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventInfo>> DeleteEventInfo(int id)
        {
            var eventInfo = await _context.EventInfo.FindAsync(id);
            if (eventInfo == null)
            {
                return NotFound();
            }

            _context.EventInfo.Remove(eventInfo);
            await _context.SaveChangesAsync();

            return eventInfo;
        }

        private bool EventInfoExists(int id)
        {
            return _context.EventInfo.Any(e => e.Id == id);
        }
    }
}
