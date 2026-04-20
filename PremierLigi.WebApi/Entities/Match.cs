namespace PremierLigi.WebApi.Entities
{
    public class Match
    {
        public int MatchId { get; set; }
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
        public DateTime MatchDate { get; set; }
        public string Status { get; set; } // "Ongoing" | "Finished" | "NotPlayed"
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public int SeasonId { get; set; }
        public Season Season { get; set; }
        public int GameWeekId { get; set; }
        public GameWeek GameWeek { get; set; }
        public int RefereeId { get; set; }
        public Referee Referee { get; set; }
        public List<MatchEvent> MatchEvents { get; set; }
        public MatchStatistics MatchStatistics { get; set; }
    }
}