using System.ComponentModel.DataAnnotations;
namespace BeerTrackerAPI.Models.Player
{
    public class ReadOnlyPlayerDto : BaseDto
    {
 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Number { get; set; }
        public string Email { get; set; }
    }
}