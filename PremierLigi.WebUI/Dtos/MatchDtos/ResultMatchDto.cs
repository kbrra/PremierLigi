namespace PremierLigi.WebUI.Dtos.MatchDtos
{
    public class ResultMatchDto
    {
        public int MatchId { get; set; }
        public int HomeTeamId { get; set; }
        public string HomeTeamName { get; set; }
        public int AwayTeamId { get; set; }
        public string AwayTeamName { get; set; }
        public DateTime MatchDate { get; set; }
        public string Status { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public int SeasonId { get; set; }
        public int GameWeekId { get; set; }
        public int RefereeId { get; set; }
    }
}
