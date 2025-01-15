using System;
using System.Collections.Generic;

namespace Onebox_backend.Models.Database;

public partial class Schade
{
    public int? SchadeId { get; set; }

    public string? Schadetype { get; set; }

    public string? TypeId { get; set; }

    public int? PakketId { get; set; }
}
