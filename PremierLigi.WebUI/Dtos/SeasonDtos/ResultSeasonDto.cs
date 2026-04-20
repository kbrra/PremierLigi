namespace PremierLigi.WebUI.Dtos.SeasonDtos
{
    public class ResultSeasonDto
    {
        public int SeasonId { get; set; }
        public string SeasonName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
