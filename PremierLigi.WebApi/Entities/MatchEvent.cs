namespace PremierLigi.WebApi.Entities
{
    public class MatchEvent
    {
        public int MatchEventId { get; set; }
        public int MatchId { get; set; }
        public Match Match { get; set; }
        // "Goal" | "YellowCard" | "RedCard" | "Substitution"
        public string ActionType { get; set; }
        public string Description { get; set; }
        public int Minute { get; set; }
    }
}