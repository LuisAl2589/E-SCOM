using ESCOM_merce.Models;
using ESCOM_merce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using MongoDB.Bson;
using System;

namespace ESCOM_merce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public UsuariosApi _usuarioService;
        public UsuariosController(UsuariosApi usuarioApi)
        {
            _usuarioService = usuarioApi;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            return _usuarioService.Get();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Usuario>> GetId(string id)
        {
            var usuario=  _usuarioService.GetId(id);
            if(usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario newUsuario)
        {
            await _usuarioService.Create(newUsuario);

            return CreatedAtAction(nameof(Get), new { id = newUsuario.Id }, newUsuario);
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, Usuario usuarioUpdate)
        {
            var usuario =  _usuarioService.GetId(id);

            if(usuario is null)
            {
                return NotFound();
            }

            usuarioUpdate.Id = usuario.Id;
            await _usuarioService.Update(id, usuarioUpdate);

            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var usuario =  _usuarioService.GetId(id);
            if(usuario is null)
            {
                return NotFound();
            }
            await _usuarioService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public JsonResult ValidarUsuario(string _correo, string _password)
        {
            return new JsonResult(_usuarioService.ValidarUsuario(_correo, _password));   
        }

    }
    
}
