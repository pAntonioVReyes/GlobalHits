using DL;
using Microsoft.EntityFrameworkCore;
using ML;

namespace BL
{
    public class Usuario
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.GlobalHitsContext context = new DL.GlobalHitsContext())
                {
                    var query = context.Usuarios.FromSqlRaw($"UsuarioGetAll").ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var usuarios in query)
                        {
                            ML.Usuario usuario = new ML.Usuario(usuarios.IdUsuario, usuarios.Nombre, usuarios.ApellidoPaterno
                                , usuarios.ApellidoMaterno, usuarios.Direccion, usuarios.Edad.Value, usuarios.Telefono, usuarios.Sexo
                                , usuarios.FechaIngreso.Value, usuarios.Salario.Value, usuarios.Sucursal.Value, usuarios.NombreSucursal);

                            if (usuario != null) result.Objects.Add(usuario);
                        }

                        if (result.Objects != null)
                        {
                            result.Correct = true;
                            result.Mensaje = "Operación exitosa";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Mensaje = "Error al traer registros";
            }

            return result;
        }

        public static ML.Result GetById(int idUsuario) 
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.GlobalHitsContext context = new DL.GlobalHitsContext())
                {
                    var query = context.Usuarios.FromSqlRaw($"UsuarioGetByID {idUsuario}").FirstOrDefault();

                    if (query != null)
                    {

                        ML.Usuario usuario = new ML.Usuario(query.IdUsuario, query.Nombre, query.ApellidoPaterno, query.ApellidoMaterno, query.Direccion, query.Edad.Value,
                            query.Telefono, query.Sexo, query.FechaIngreso.Value, query.Salario.Value, query.Sucursal.Value, query.NombreSucursal);
                        

                        if (usuario != null)
                        {
                            result.Correct = true;
                            result.Mensaje = "Operación exitosa";
                            result.Object = usuario;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Mensaje = "Error al traer registros";
            }

            return result;
        }

        public static ML.Result Delete(int idUsuario) 
        {
            ML.Result result = new ML.Result();

            try 
            {
                using (DL.GlobalHitsContext context = new DL.GlobalHitsContext()) 
                {
                    var query = context.Database.ExecuteSqlRaw($"UsuarioDelete {idUsuario}");

                    if (query > 0) 
                    {
                        result.Correct = true;
                        result.Mensaje = "Operación exitosa";
                    }
                }
            } catch (Exception ex) 
            {
                result.Correct = false;
                result.Ex = ex;
                result.Mensaje = "Érror al encontrar registros"+result.Ex;
            }

            return result;  
        }

        public static ML.Result Add(ML.Usuario usuario) 
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.GlobalHitsContext context = new DL.GlobalHitsContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UsuarioAdd '{usuario.Nombre}', '{usuario.ApellidoPaterno}', '{usuario.ApellidoMaterno}', '{usuario.ApellidoPaterno}', '{usuario.Direccion}', {usuario.Edad}, '{usuario.Edad}', '{usuario.Telefono}', '{usuario.Sexo}', {usuario.Salario}, {usuario.Sucursal}");

                    if (query > 1)
                    {
                            result.Correct = true;
                            result.Mensaje = "Operación exitosa";
                            result.Object = usuario;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Mensaje = "Error al realizar operación"+ result.Ex;
            }

            return result;
        }

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.GlobalHitsContext context = new DL.GlobalHitsContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UsuarioUpdate '{usuario.Nombre}', '{usuario.ApellidoPaterno}', '{usuario.ApellidoMaterno}', '{usuario.ApellidoPaterno}', '{usuario.Direccion}', {usuario.Edad}, '{usuario.Edad}', '{usuario.Telefono}', '{usuario.Sexo}', {usuario.Salario}, {usuario.Sucursal}, {usuario.IdUsuario}");

                    if (query > 1)
                    {
                        result.Correct = true;
                        result.Mensaje = "Operación exitosa";
                        result.Object = usuario;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Mensaje = "Error al realizar operación" + result.Ex;
            }

            return result;
        }
    }
}