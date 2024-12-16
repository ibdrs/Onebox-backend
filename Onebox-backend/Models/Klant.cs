using System;
using System.Collections.Generic;

namespace Onebox_backend.Models;

public partial class Klant
{
    public int KlantId { get; set; }

    public string? Naam { get; set; }

    public string? Adres { get; set; }

    public string? Woonplaats { get; set; }

    public string? Postcode { get; set; }
}
