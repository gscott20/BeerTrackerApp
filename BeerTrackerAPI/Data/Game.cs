using System;
using System.Collections.Generic;

namespace BeerTrackerAPI.Data;

public partial class Game
{
    public int Id { get; set; }

    public string? Opponent { get; set; }

    public DateTime? Date { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<PlayerGameBeer> PlayerGameBeers { get; set; } = new List<PlayerGameBeer>();
}
