using System;
using System.Collections.Generic;

namespace Onebox_backend.Models.Database;

public partial class Box
{
    private bool state;

    public int Id { get; set; }

    public int KlantId { get; set; }

    public bool State { get; set; }
}
