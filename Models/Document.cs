using System;
using System.Collections.Generic;

namespace TramitesAPI.Models;

public partial class Document
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime Auditoria { get; set; }

    public sbyte Activo { get; set; }

    public int DocumetTipeId { get; set; }

    public virtual Documettipe DocumetTipe { get; set; } = null!;
}
