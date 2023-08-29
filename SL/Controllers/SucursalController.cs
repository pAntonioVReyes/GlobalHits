using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/Sucursal")]
    public class SucursalController : ControllerBase
    {
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Index()
        {
            ML.Result result = BL.Sucursal.GetAll();

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
