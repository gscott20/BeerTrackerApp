using System;
using System.Collections.Generic;

namespace BeerTrackerAPI.Data;

public partial class Beer
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Bio { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<PlayerGameBeer> PlayerGameBeers { get; set; } = new List<PlayerGameBeer>();
}
