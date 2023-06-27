using ESCOM_merce.Models;
using ESCOM_merce.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ESCOM_merce.Controllers
{
    public class HomeController : Controller
    {
        public ProductosApi _productoService;
        public UsuariosApi _usuarioService;
   
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ProductosApi productoService, UsuariosApi usuarioApi)
        {
            _logger = logger;
            _productoService = productoService;
            _usuarioService = usuarioApi;
        }

        public IActionResult Index()
        {
            var productos = _productoService.Get();
            var lvpv = new List<VProductoVendedor>();
            foreach (var item in productos)
            {
                var vpv = new VProductoVendedor();
                var vendedor = new Usuario();
                vendedor = _usuarioService.GetId(item.IdVendedor);
                vpv.Producto = item;
                vpv.Usuario = vendedor;
                lvpv.Add(vpv);
            }

            return View(lvpv);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}