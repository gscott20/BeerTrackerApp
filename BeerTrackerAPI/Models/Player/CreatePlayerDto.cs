namespace BeerTrackerAPI.Models.Player
{
    public class CreatePlayerDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Number { get; set; }
        public string? Email { get; set; }
    }
}