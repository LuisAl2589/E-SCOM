using ESCOM_merce.Models;
using ESCOM_merce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESCOM_merce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public UsuariosApi _usuarioApi;
        public UsuariosController(UsuariosApi usuarioApi)
        {
            _usuarioApi = usuarioApi;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            return _usuarioApi.Get();
        }
    }
    
}
