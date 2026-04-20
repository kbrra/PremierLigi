using System.Text.RegularExpressions;

namespace PremierLigi.WebApi.Entities
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string City { get; set; }
        public string LogoUrl { get; set; }
        public int StadiumId { get; set; }
        public Stadium Stadium { get; set; }
        public List<Match> HomeMatches { get; set; }
        public List<Match> AwayMatches { get; set; }
    }
}