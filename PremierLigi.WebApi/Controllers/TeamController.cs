using Microsoft.AspNetCore.Mvc;
using PremierLigi.WebApi.Context;
using PremierLigi.WebApi.Entities;

namespace PremierLigi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ApiContext _context;

        public TeamController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult TeamList()
        {
            var values = _context.Teams.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
            return Ok("Takım Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteTeam(int id)
        {
            var values = _context.Teams.Find(id);
            _context.Teams.Remove(values);
            _context.SaveChanges();
            return Ok("Takım Silindi");
        }

        [HttpGet("GetTeam")]
        public IActionResult GetTeam(int id)
        {
            var values = _context.Teams.Find(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateTeam(Team team)
        {
            _context.Teams.Update(team);
            _context.SaveChanges();
            return Ok("Takım Güncellendi");
        }
    }
}