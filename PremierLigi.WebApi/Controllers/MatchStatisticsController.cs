using Microsoft.AspNetCore.Mvc;
using PremierLigi.WebApi.Context;
using PremierLigi.WebApi.Entities;

namespace PremierLigi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchStatisticsController : ControllerBase
    {
        private readonly ApiContext _context;

        public MatchStatisticsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult StatisticsList()
        {
            var values = _context.MatchStatistics.ToList();
            return Ok(values);
        }


        [HttpGet("GetByMatch")]
        public IActionResult GetByMatch(int matchId)
        {
            var values = _context.MatchStatistics.FirstOrDefault(s => s.MatchId == matchId);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateStatistics(MatchStatistics matchStatistics)
        {
            _context.MatchStatistics.Add(matchStatistics);
            _context.SaveChanges();
            return Ok("İstatistik Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteStatistics(int id)
        {
            var values = _context.MatchStatistics.Find(id);
            _context.MatchStatistics.Remove(values);
            _context.SaveChanges();
            return Ok("İstatistik Silindi");
        }

        [HttpGet("GetStatistics")]
        public IActionResult GetStatistics(int id)
        {
            var values = _context.MatchStatistics.Find(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateStatistics(MatchStatistics matchStatistics)
        {
            _context.MatchStatistics.Update(matchStatistics);
            _context.SaveChanges();
            return Ok("İstatistik Güncellendi");
        }

    }
}