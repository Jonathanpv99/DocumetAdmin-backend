using System;
using System.Collections.Generic;

namespace TramitesAPI.Models;

public partial class Tramite
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Codigo { get; set; }

    public DateTime Auditoria { get; set; }

    public sbyte Activo { get; set; }

    public virtual ICollection<Documentsfortramite> Documentsfortramites { get; set; } = new List<Documentsfortramite>();
}
