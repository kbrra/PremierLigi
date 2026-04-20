using Microsoft.AspNetCore.Mvc;
using PremierLigi.WebApi.Context;
using PremierLigi.WebApi.Entities;

namespace PremierLigi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StadiumController : ControllerBase
    {
        private readonly ApiContext _context;

        public StadiumController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult StadiumList()
        {
            var values = _context.Stadiums.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateStadium(Stadium stadium)
        {
            _context.Stadiums.Add(stadium);
            _context.SaveChanges();
            return Ok("Stadyum Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteStadium(int id)
        {
            var values = _context.Stadiums.Find(id);
            _context.Stadiums.Remove(values);
            _context.SaveChanges();
            return Ok("Stadyum Silindi");
        }

        [HttpGet("GetStadium")]
        public IActionResult GetStadium(int id)
        {
            var values = _context.Stadiums.Find(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateStadium(Stadium stadium)
        {
            _context.Stadiums.Update(stadium);
            _context.SaveChanges();
            return Ok("Stadyum Güncellendi");
        }
    }
}