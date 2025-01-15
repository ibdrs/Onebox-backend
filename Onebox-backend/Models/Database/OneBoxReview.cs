using System;
using System.Collections.Generic;

namespace Onebox_backend.Models.Database;

public partial class OneBoxReview
{
    public int KlantId { get; set; }

    public int Cijfer { get; set; }

    public string BetrekkingOp { get; set; } = null!;

    public int Datum { get; set; }
}
