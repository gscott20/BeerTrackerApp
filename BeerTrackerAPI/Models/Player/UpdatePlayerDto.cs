using System.ComponentModel.DataAnnotations;

namespace BeerTrackerAPI.Models.Player
{
    public class UpdatePlayerDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        public int Number { get; set; }
        public string? Email { get; set; }
    }
}