using System;
using System.Collections.Generic;

namespace Onebox_backend.Models.Database;

public partial class Leveringen
{
    public int Id { get; set; }

    public string? Vertrektijd { get; set; }

    public string? Retourtijd { get; set; }

    public string? Tijd { get; set; }

    public string? Datum { get; set; }

    public string? Vervoersmethode { get; set; }

    public string? Leveringsituatie { get; set; }

    public string? ReactieAanDeur { get; set; }

    public string? TevredenheidKlant { get; set; }

    public string? Pakketintact { get; set; }

    public int? KlantId { get; set; }

    public int? PakketId { get; set; }

    public string TrackAndTraceCode { get; set; } = null!;
}
