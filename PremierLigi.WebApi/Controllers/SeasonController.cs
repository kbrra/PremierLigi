using Microsoft.AspNetCore.Mvc;
using PremierLigi.WebApi.Context;
using PremierLigi.WebApi.Entities;

namespace PremierLigi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private readonly ApiContext _context;

        public SeasonController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult SeasonList()
        {
            var values = _context.Seasons.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSeason(Season season)
        {
            _context.Seasons.Add(season);
            _context.SaveChanges();
            return Ok("Sezon Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteSeason(int id)
        {
            var values = _context.Seasons.Find(id);
            _context.Seasons.Remove(values);
            _context.SaveChanges();
            return Ok("Sezon Silindi");
        }

        [HttpGet("GetSeason")]
        public IActionResult GetSeason(int id)
        {
            var values = _context.Seasons.Find(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateSeason(Season season)
        {
            _context.Seasons.Update(season);
            _context.SaveChanges();
            return Ok("Sezon Güncellendi");
        }
    }
}