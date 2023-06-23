using ESCOM_merce.Models;
using ESCOM_merce.Services;
using Microsoft.AspNetCore.Mvc;

namespace ESCOM_merce.Controllers
{
    public class VProductoController : Controller
    {

        public ProductosApi _productoService;
        public VProductoController(ProductosApi productoApi)
        {
            _productoService = productoApi;
        }

        [HttpPost]
        public IActionResult CrearProducto(Producto _producto)
        {
            var producto = _productoService.Create(_producto);

            if (producto != null)
            {
                return RedirectToAction("ProductosVendedor", "VVendedor");
            }
            return RedirectToAction("RegistroProducto", "VVendedor");
        }

        [HttpPost]
        public IActionResult EliminarProducto(string _idProducto)
        {
            var producto = _productoService.Delete(_idProducto);

            
                return RedirectToAction("ProductosVendedor", "VVendedor");
            
            
        }
    }
}
