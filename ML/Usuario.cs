namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Direccion { get; set; }
        public byte Edad { get; set; }
        public string Telefono { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public decimal Salario { get; set; }
        public ML.Sucursal Sucursal { get; set; }
        public List<object>? Usuarios { get; set; }

        public Usuario() { }
        public Usuario(int idUsuario, string nombre, string apellidoP, string apellidoM, string direccion, byte edad,
            string telefono, string sexo, DateTime fechaIngreso, decimal salario, int idSucursal)
        {
            this.IdUsuario = idUsuario;
            this.Nombre = nombre;
            this.ApellidoPaterno = apellidoP;
            this.ApellidoMaterno = apellidoM;
            this.Direccion = direccion;
            this.Edad = edad;
            this.Telefono = telefono;
            this.Sexo = sexo;
            this.FechaIngreso = fechaIngreso;
            this.Salario = salario;
            this.Sucursal = new ML.Sucursal();
            this.Sucursal.IdSucursal = idSucursal;
        }
        public Usuario(int idUsuario, string nombre, string apellidoP, string apellidoM, string direccion, byte edad,
            string telefono, string sexo, DateTime fechaIngreso, decimal salario, int idSucursal, string nombreSucursal) 
        {
            this.IdUsuario = idUsuario;
            this.Nombre = nombre;
            this.ApellidoPaterno = apellidoP;
            this.ApellidoMaterno = apellidoM;
            this.Direccion = direccion;
            this.Edad = edad;
            this.Telefono = telefono;
            this.Sexo = sexo;
            this.FechaIngreso = fechaIngreso;
            this.Salario = salario;
            this.Sucursal = new ML.Sucursal();
            this.Sucursal.IdSucursal = idSucursal;
            this.Sucursal.Nombre = nombreSucursal;
        }
    }
}