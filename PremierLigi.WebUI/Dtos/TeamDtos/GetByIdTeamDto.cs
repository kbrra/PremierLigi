namespace PremierLigi.WebUI.Dtos.TeamDtos
{
    public class GetByIdTeamDto
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string City { get; set; }
        public string LogoUrl { get; set; }
        public int StadiumId { get; set; }
    }
}
