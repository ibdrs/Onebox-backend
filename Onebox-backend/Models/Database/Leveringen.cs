using System;
using System.Collections.Generic;

namespace Onebox_backend.Models.Database;

public partial class Leveringen
{
    public int Id { get; set; }

    public TimeOnly? Vertrektijd { get; set; }

    public TimeOnly? Retourtijd { get; set; }

    public TimeOnly? Tijd { get; set; }

    public DateOnly? Datum { get; set; }

    public string? Vervoersmethode { get; set; }

    public string? Leveringsituatie { get; set; }

    public string? ReactieAanDeur { get; set; }

    public string? TevredenheidKlant { get; set; }

    public bool? Pakketintact { get; set; }

    public int KlantId { get; set; }
}
