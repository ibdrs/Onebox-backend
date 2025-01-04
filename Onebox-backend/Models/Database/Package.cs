using System;
using System.Collections.Generic;

namespace Onebox_backend.Models.Database;

public partial class Package
{
    public int PackageId { get; set; }

    public string? TrackingCode { get; set; }

    public string? PackageSize { get; set; }

    public int? PackageWeight { get; set; }

    public int BoxId { get; set; }
}
