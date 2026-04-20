using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremierLigi.WebApi.Context;
using PremierLigi.WebApi.Entities;

namespace PremierLigi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly ApiContext _context;

        public MatchController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult MatchList()
        {
            var values = _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Include(m => m.Season)
                .Include(m => m.GameWeek)
                .Include(m => m.Referee)
                .Select(m => new
                {
                    m.MatchId,
                    m.HomeTeamId,
                    HomeTeamName = m.HomeTeam.TeamName,
                    m.AwayTeamId,
                    AwayTeamName = m.AwayTeam.TeamName,
                    m.MatchDate,
                    m.Status,
                    m.HomeScore,
                    m.AwayScore,
                    m.SeasonId,
                    m.GameWeekId,
                    m.RefereeId
                })
                .ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMatch(Match match)
        {
            _context.Matches.Add(match);
            _context.SaveChanges();
            return Ok("Maç Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteMatch(int id)
        {
            var values = _context.Matches.Find(id);
            _context.Matches.Remove(values);
            _context.SaveChanges();
            return Ok("Maç Silindi");
        }

        [HttpGet("GetMatch")]
        public IActionResult GetMatch(int id)
        {
            var values = _context.Matches
                .Include(m => m.HomeTeam)
                .Include(m => m.AwayTeam)
                .Select(m => new
                {
                    m.MatchId,
                    m.HomeTeamId,
                    HomeTeamName = m.HomeTeam.TeamName,
                    m.AwayTeamId,
                    AwayTeamName = m.AwayTeam.TeamName,
                    m.MatchDate,
                    m.Status,
                    m.HomeScore,
                    m.AwayScore,
                    m.SeasonId,
                    m.GameWeekId,
                    m.RefereeId
                })
                .FirstOrDefault(m => m.MatchId == id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateMatch(Match match)
        {
            _context.Matches.Update(match);
            _context.SaveChanges();
            return Ok("Maç Güncellendi");
        }

        [HttpGet("Standings")]
        public IActionResult GetStandings()
        {
            var teams = _context.Teams.ToList();
            var matches = _context.Matches
                .Where(m => m.Status == "Finished")
                .ToList();

            var standings = teams.Select(team =>
            {
                var homeMatches = matches.Where(m => m.HomeTeamId == team.TeamId).ToList();
                var awayMatches = matches.Where(m => m.AwayTeamId == team.TeamId).ToList();

                int played = homeMatches.Count + awayMatches.Count;
                int won = homeMatches.Count(m => m.HomeScore > m.AwayScore)
                        + awayMatches.Count(m => m.AwayScore > m.HomeScore);
                int drawn = homeMatches.Count(m => m.HomeScore == m.AwayScore)
                          + awayMatches.Count(m => m.HomeScore == m.AwayScore);
                int lost = played - won - drawn;
                int points = (won * 3) + (drawn * 1);
                int goalsFor = homeMatches.Sum(m => m.HomeScore ?? 0)
                             + awayMatches.Sum(m => m.AwayScore ?? 0);
                int goalsAgainst = homeMatches.Sum(m => m.AwayScore ?? 0)
                                 + awayMatches.Sum(m => m.HomeScore ?? 0);

                var allTeamMatches = matches
                    .Where(m => m.HomeTeamId == team.TeamId || m.AwayTeamId == team.TeamId)
                    .OrderByDescending(m => m.MatchDate)
                    .Take(5)
                    .Select(m =>
                    {
                        if (m.HomeTeamId == team.TeamId)
                            return m.HomeScore > m.AwayScore ? "W" : m.HomeScore == m.AwayScore ? "D" : "L";
                        else
                            return m.AwayScore > m.HomeScore ? "W" : m.AwayScore == m.HomeScore ? "D" : "L";
                    }).ToList();

                return new
                {
                    TeamId = team.TeamId,
                    TeamName = team.TeamName,
                    Played = played,
                    Won = won,
                    Drawn = drawn,
                    Lost = lost,
                    GoalsFor = goalsFor,
                    GoalsAgainst = goalsAgainst,
                    GoalDifference = goalsFor - goalsAgainst,
                    Points = points,
                    Last5 = allTeamMatches
                };
            })
            .OrderByDescending(s => s.Points)
            .ThenByDescending(s => s.GoalDifference)
            .ToList();

            return Ok(standings);
        }
    }
}