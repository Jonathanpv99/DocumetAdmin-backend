using System;
using System.Collections.Generic;

namespace TramitesAPI.Models;

public partial class Documentsfortramite
{
    public int DocumentsId { get; set; }

    public int TramitesId { get; set; }

    public virtual Tramite Tramites { get; set; } = null!;
}
