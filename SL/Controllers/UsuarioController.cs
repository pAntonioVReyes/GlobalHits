using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/Usuario")]
    public class UsuarioController : ControllerBase
    {
        // GET GETALL
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            ML.Result result = BL.Usuario.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else 
            {
                return BadRequest();
            }

        }

        // GET GETById
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetAll(int idUsuario)
        {
            ML.Result result = BL.Usuario.GetById(idUsuario);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }

        }

        //POST AGREGAR
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(ML.Usuario usuario) 
        {
            ML.Result result = BL.Usuario.Add(usuario);

            if (result.Correct)
            {
                return Ok(result);
            }
            else 
            {
                return BadRequest();
            }
        }

        //PUT ACTUALIZAR
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(ML.Usuario usuario) 
        {
            ML.Result result = BL.Usuario.Update(usuario);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        //DELETE DELETE
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int idUsuario)
        {
            ML.Result result = BL.Usuario.Delete(idUsuario);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
