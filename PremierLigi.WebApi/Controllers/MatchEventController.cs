using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremierLigi.WebApi.Context;
using PremierLigi.WebApi.Entities;

namespace PremierLigi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchEventController : ControllerBase
    {
        private readonly ApiContext _context;

        public MatchEventController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult MatchEventList()
        {
            var values = _context.MatchEvents
                .Include(e => e.Match)
                .ToList();
            return Ok(values);
        }

        [HttpGet("GetByMatch")]
        public IActionResult GetEventsByMatch(int matchId)
        {
            var values = _context.MatchEvents
                .Where(e => e.MatchId == matchId)
                .OrderBy(e => e.Minute)
                .ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMatchEvent(MatchEvent matchEvent)
        {
            _context.MatchEvents.Add(matchEvent);
            _context.SaveChanges();
            return Ok("Maç Olayı Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteMatchEvent(int id)
        {
            var values = _context.MatchEvents.Find(id);
            _context.MatchEvents.Remove(values);
            _context.SaveChanges();
            return Ok("Maç Olayı Silindi");
        }

        [HttpGet("GetMatchEvent")]
        public IActionResult GetMatchEvent(int id)
        {
            var values = _context.MatchEvents.Find(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateMatchEvent(MatchEvent matchEvent)
        {
            _context.MatchEvents.Update(matchEvent);
            _context.SaveChanges();
            return Ok("Maç Olayı Güncellendi");
        }
    }
}