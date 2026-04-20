namespace PremierLigi.WebUI.Dtos.GameWeekDtos
{
    public class UpdateGameWeekDto
    {
        public int GameWeekId { get; set; }
        public int WeekNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SeasonId { get; set; }
    }
}
