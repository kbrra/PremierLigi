namespace PremierLigi.WebApi.Dtos.MatchStatisticsDtos
{
    public class ResultMatchStatisticsDto
    {
        public int MatchStatisticsId { get; set; }
        public int MatchId { get; set; }
        public int HomeFirstHalfGoals { get; set; }
        public int HomeSecondHalfGoals { get; set; }
        public int AwayFirstHalfGoals { get; set; }
        public int AwaySecondHalfGoals { get; set; }
        public int HomePossession { get; set; }
        public int AwayPossession { get; set; }
        public int HomeShots { get; set; }
        public int AwayShots { get; set; }
        public int HomeCorners { get; set; }
        public int AwayCorners { get; set; }
    }
}
