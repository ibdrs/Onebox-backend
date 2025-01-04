using System;
using System.Collections.Generic;

namespace Onebox_backend.Models.Database;

public partial class Box
{
    public int Id { get; set; }

    public int KlantId { get; set; }

    public bool State { get; set; }

    public virtual Klant Klant { get; set; } = null!;
}
