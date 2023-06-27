using ESCOM_merce.Services;
using ESCOM_merce.Models;

using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace ESCOM_merce.Controllers
{
    public class VVendedorController : Controller
    {
        public UsuariosApi _usuarioService;
        public ProductosApi _productoService;

        public VVendedorController(UsuariosApi usuarioApi, ProductosApi productoService)
        {
            _usuarioService = usuarioApi;
            _productoService = productoService;

        }
        public IActionResult Perfil()
        {
            var usuario = _usuarioService.GetId(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (usuario == null)
            {
                return RedirectToAction("Index", "Home");

            }

            return View(usuario);
        }

        public IActionResult ProductosVendedor()
        {
            var productos = _productoService.GetIdVendedor(User.FindFirstValue(ClaimTypes.NameIdentifier));
            
            return View(productos);
        }

        public IActionResult RegistroProducto()
        {

            return View();
        }
        [HttpPost]
        public IActionResult EditarProducto(string _idProducto)
        {
            var producto = _productoService.GetId(_idProducto);

            return View(producto);
        }
        [HttpPost]
        public IActionResult Eliminar(string _idUsuario)
        {

           var vendedor= _usuarioService.Delete(_idUsuario);
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult VEditar(string _idUsuario)
        {
            var usuario = _usuarioService.GetId(_idUsuario);
            if (usuario == null)
            {
                return RedirectToAction("Perfil", "VVendedor");
            }
            return View(usuario);
        }
    }
}
