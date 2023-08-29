using System;
using System.Collections.Generic;

namespace DL;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public string? Direccion { get; set; }

    public byte? Edad { get; set; }

    public string? Telefono { get; set; }

    public string? Sexo { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public decimal? Salario { get; set; }

    public int? Sucursal { get; set; }

    public virtual Sucursal? SucursalNavigation { get; set; }

    public string NombreSucursal { get; set; }
}
