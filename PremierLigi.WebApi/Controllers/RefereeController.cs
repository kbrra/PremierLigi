using Microsoft.AspNetCore.Mvc;
using PremierLigi.WebApi.Context;
using PremierLigi.WebApi.Entities;

namespace PremierLigi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefereeController : ControllerBase
    {
        private readonly ApiContext _context;

        public RefereeController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult RefereeList()
        {
            var values = _context.Referees.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateReferee(Referee referee)
        {
            _context.Referees.Add(referee);
            _context.SaveChanges();
            return Ok("Hakem Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteReferee(int id)
        {
            var values = _context.Referees.Find(id);
            _context.Referees.Remove(values);
            _context.SaveChanges();
            return Ok("Hakem Silindi");
        }

        [HttpGet("GetReferee")]
        public IActionResult GetReferee(int id)
        {
            var values = _context.Referees.Find(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateReferee(Referee referee)
        {
            _context.Referees.Update(referee);
            _context.SaveChanges();
            return Ok("Hakem Güncellendi");
        }
    }
}