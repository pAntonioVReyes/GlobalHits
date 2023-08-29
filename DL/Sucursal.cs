using System;
using System.Collections.Generic;

namespace DL;

public partial class Sucursal
{
    public int IdSucursal { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
