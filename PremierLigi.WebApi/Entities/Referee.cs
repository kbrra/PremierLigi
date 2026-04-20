namespace PremierLigi.WebApi.Entities
{
    public class Referee
    {
        public int RefereeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public List<Match> Matches { get; set; }
    }
}
