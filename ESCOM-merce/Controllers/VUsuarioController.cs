using ESCOM_merce.Models;
using ESCOM_merce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims; 


namespace ESCOM_merce.Controllers
{
    public class VUsuarioController : Controller
    {
        public UsuariosApi _usuarioService;
        public VUsuarioController(UsuariosApi usuarioApi)
        {
            _usuarioService = usuarioApi;
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index","Home");
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Usuario _usuario)
        {
            var usuario = _usuarioService.ValidarUsuario(_usuario.Correo, _usuario.Password);

            if (usuario != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,usuario.Nombre),
                    new Claim("Correo",usuario.Correo),
                    new Claim(ClaimTypes.NameIdentifier,usuario.Id),
                    new Claim(ClaimTypes.Role,usuario.TipoUsuario)
                };

                var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Login", "VUsuario");
        }

        [HttpPost]
        public IActionResult Registrar(Usuario _usuario)
        {
            var usuario = _usuarioService.Create(_usuario);

            if (usuario != null)
            {
                return RedirectToAction("Login", "VUsuario");
            }
            return RedirectToAction("Registro", "VUsuario");
        }

    }
}
