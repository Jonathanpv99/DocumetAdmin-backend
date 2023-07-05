using System;
using System.Collections.Generic;

namespace TramitesAPI.Models;

public partial class Documettipe
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Codigo { get; set; }

    public DateTime Auditoria { get; set; }

    public sbyte Activo { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}
