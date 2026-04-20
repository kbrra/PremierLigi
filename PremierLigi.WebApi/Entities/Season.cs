namespace PremierLigi.WebApi.Entities
{
    public class Season
    {
        public int SeasonId { get; set; }
        public string SeasonName { get; set; } // Örn: 2024/25
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public List<Match> Matches { get; set; }
    }
}
