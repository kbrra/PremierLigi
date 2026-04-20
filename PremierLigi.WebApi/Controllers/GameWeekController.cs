using Microsoft.AspNetCore.Mvc;
using PremierLigi.WebApi.Context;
using PremierLigi.WebApi.Entities;

namespace PremierLigi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameWeekController : ControllerBase
    {
        private readonly ApiContext _context;

        public GameWeekController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GameWeekList()
        {
            var values = _context.GameWeeks.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateGameWeek(GameWeek gameWeek)
        {
            _context.GameWeeks.Add(gameWeek);
            _context.SaveChanges();
            return Ok("Maç Haftası Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteGameWeek(int id)
        {
            var values = _context.GameWeeks.Find(id);
            _context.GameWeeks.Remove(values);
            _context.SaveChanges();
            return Ok("Maç Haftası Silindi");
        }

        [HttpGet("GetGameWeek")]
        public IActionResult GetGameWeek(int id)
        {
            var values = _context.GameWeeks.Find(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateGameWeek(GameWeek gameWeek)
        {
            _context.GameWeeks.Update(gameWeek);
            _context.SaveChanges();
            return Ok("Maç Haftası Güncellendi");
        }
    }
}