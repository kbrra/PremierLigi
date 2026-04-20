namespace PremierLigi.WebUI.Dtos.MatchEventDtos
{
    public class GetByIdMatchEventDto
    {
        public int MatchEventId { get; set; }
        public int MatchId { get; set; }
        public string ActionType { get; set; }
        public string Description { get; set; }
        public int Minute { get; set; }
    }
}
