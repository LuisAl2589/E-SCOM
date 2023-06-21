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

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Usuario>> GetId(string id)
        {
            var usuario= await _usuarioApi.GetId(id);
            if(usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario newUsuario)
        {
            await _usuarioApi.Create(newUsuario);

            return CreatedAtAction(nameof(Get), new { id = newUsuario.Id }, newUsuario);
        }
    }
    
}
