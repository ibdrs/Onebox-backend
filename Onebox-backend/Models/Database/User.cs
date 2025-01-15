using System;
using System.Collections.Generic;

namespace Onebox_backend.Models.Database;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int KlantId { get; set; }

    public virtual Klant? Klant { get; set; }
}
