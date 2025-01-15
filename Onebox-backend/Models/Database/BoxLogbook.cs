using System;
using System.Collections.Generic;

namespace Onebox_backend.Models.Database;

public partial class BoxLogbook
{
    public int Id { get; set; }

    public int BoxId { get; set; }

    public DateTime? AanvraagOpen { get; set; }

    public DateTime? UitvoeringOpen { get; set; }

    public DateTime? AanvraagDicht { get; set; }

    public DateTime? UitvoeringDicht { get; set; }
}
