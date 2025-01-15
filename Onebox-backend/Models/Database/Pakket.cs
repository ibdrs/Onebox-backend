using System;
using System.Collections.Generic;

namespace Onebox_backend.Models.Database;

public partial class Pakket
{
    public int? PakketId { get; set; }

    public string? Groote { get; set; }

    public string? Gewicht { get; set; }

    public int? Verzekering { get; set; }

    public int? Intact { get; set; }
}
