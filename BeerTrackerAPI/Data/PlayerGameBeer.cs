using System;
using System.Collections.Generic;

namespace BeerTrackerAPI.Data;

public partial class PlayerGameBeer
{
    public int Id { get; set; }

    public int? GameId { get; set; }

    public int? BeerId { get; set; }

    public decimal? TotalBeer { get; set; }

    public virtual Beer? Beer { get; set; }

    public virtual Game? Game { get; set; }
}
