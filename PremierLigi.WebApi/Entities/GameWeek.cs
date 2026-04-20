namespace PremierLigi.WebApi.Entities
{
    public class GameWeek
    {
        public int GameWeekId { get; set; }
        public int WeekNumber { get; set; } // Örn: 1, 2, 3...
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SeasonId { get; set; }
        public Season Season { get; set; }
        public List<Match> Matches { get; set; }
    }
}
