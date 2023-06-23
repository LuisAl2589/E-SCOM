using ESCOM_merce.Services;
using ESCOM_merce.Models;

using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        public IActionResult EditarProducto()
        {

            return View();
        }
    }
}
