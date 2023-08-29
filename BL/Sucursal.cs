using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Sucursal
    {
        public static ML.Result GetAll() 
        {
            ML.Result result = new ML.Result();
            
            try 
            {
                using (DL.GlobalHitsContext context = new DL.GlobalHitsContext()) 
                {
                    var query = context.Sucursals.FromSqlRaw($"SucursalGetAll").ToList();

                    if (query != null) 
                    {
                        result.Objects = new List<object>();

                        foreach (var sucursales in query) 
                        {
                            ML.Sucursal sucursal =new ML.Sucursal(sucursales.IdSucursal, sucursales.Nombre);

                            if(sucursal != null) result.Objects.Add(sucursal);
                        }

                        if (result.Objects != null) 
                        {
                            result.Correct = true;
                            result.Mensaje = "Operación exitosa";
                        }
                    }
                }
            } catch (Exception ex) 
            {
                result.Correct = false;
                result.Ex = ex;
                result.Mensaje = "Error al traer registros";
            }

            return result;
        }
    }
}
