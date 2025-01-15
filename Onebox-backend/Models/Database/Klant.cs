using System;
using System.Collections.Generic;

namespace Onebox_backend.Models.Database;

public partial class Klant
{
    public int KlantId { get; set; }

    public string? Naam { get; set; }

    public string? Adres { get; set; }

    public string? Woonplaats { get; set; }

    public string? Postcode { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
    public virtual ICollection<Box> Boxes { get; set; } = new List<Box>();
}
