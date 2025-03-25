using System;
using System.Collections.Generic;

namespace BeerTrackerAPI.Data;

public partial class Player
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? Number { get; set; }

    public string? Email { get; set; }
}
