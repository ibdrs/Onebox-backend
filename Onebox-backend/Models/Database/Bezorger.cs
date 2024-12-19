using System;
using System.Collections.Generic;

namespace Onebox_backend.Models.Database;

public partial class Bezorger
{
    public int BezorgerId { get; set; }

    public string? Woonadres { get; set; }

    public DateOnly? DatumInDienst { get; set; }

    public string? Regio { get; set; }

    public string? Postbezorgbedrijf { get; set; }
}
