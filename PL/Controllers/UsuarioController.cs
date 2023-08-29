using DL;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        private IHostingEnvironment environment;
        private IConfiguration configuration;

        public UsuarioController(IHostingEnvironment _environment, IConfiguration _configuration)
        {
            environment = _environment;
            configuration = _configuration;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result resultUsuario = new ML.Result();
            ML.Usuario usuario = new ML.Usuario();

            using (HttpClient client = new HttpClient()) 
            {
                string webAPI = configuration["webAPI"];
                client.BaseAddress = new Uri(webAPI);

                var responseTask = client.GetAsync("GetAll");
                responseTask.Wait();

                var resultTask = responseTask.Result;

                if (resultTask.IsSuccessStatusCode) 
                {
                    var readTask = resultTask.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    resultUsuario.Objects = new List<object>();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Usuario resultItemList = new ML.Usuario();
                        resultItemList.Sucursal = new ML.Sucursal();

                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(resultItem.ToString());
                        resultUsuario.Objects.Add(resultItemList);
                    }

                    usuario.Usuarios = resultUsuario.Objects;
                    
                }
            }
            return View(usuario);   
        }

        [HttpGet]
        public ActionResult Form(int idUsuario) 
        {

            if (idUsuario == 0)
            {
                return View();
            }
            else 
            {
                ML.Usuario resultItem = new ML.Usuario();

                using (HttpClient client = new HttpClient()) 
                {
                    string webAPI = configuration["webAPI"];
                    client.BaseAddress = new Uri(webAPI);

                    var responseTask = client.GetAsync($"GetById/{idUsuario}");
                    responseTask.Wait();

                    var resultTask = responseTask.Result;

                    if (resultTask.IsSuccessStatusCode)
                    {
                        var readTask = resultTask.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                       
                        resultItem.Sucursal = new ML.Sucursal();

                        resultItem = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(readTask.ToString());
                    }
                }
                return View(resultItem);
            }
            
        }


    }
}
