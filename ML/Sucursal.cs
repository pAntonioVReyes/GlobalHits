﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Sucursal
    {
        public int IdSucursal { get; set; }
        public string Nombre { get; set; }
        public List<ML.Sucursal>? Sucursales { get; set; }
        public Sucursal() { }
        public Sucursal(int idSucursal, string nombre) 
        {
            this.IdSucursal = idSucursal;
            this.Nombre = nombre;
        }
    }
}