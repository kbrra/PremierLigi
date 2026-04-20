namespace PremierLigi.WebUI.Dtos.MatchDtos
{
    public class CreateMatchDto
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public DateTime MatchDate { get; set; }
        public string Status { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public int SeasonId { get; set; }
        public int GameWeekId { get; set; }
        public int RefereeId { get; set; }
    }
}
