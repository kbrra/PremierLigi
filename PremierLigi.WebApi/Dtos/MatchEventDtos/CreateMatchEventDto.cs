namespace PremierLigi.WebApi.Dtos.MatchEventDtos
{
    public class CreateMatchEventDto
    {
        public int MatchId { get; set; }
        public string ActionType { get; set; }
        public string Description { get; set; }
        public int Minute { get; set; }
    }
}
