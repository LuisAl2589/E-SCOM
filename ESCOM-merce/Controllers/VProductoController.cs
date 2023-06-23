using ESCOM_merce.Models;
using ESCOM_merce.Services;
using Microsoft.AspNetCore.Mvc;

namespace ESCOM_merce.Controllers
{
    public class VProductoController : Controller
    {

        public ProductosApi _productoService;
        public UsuariosApi _usuarioService;

        public VProductoController(ProductosApi productoApi, UsuariosApi usuarioApi)
        {
            _productoService = productoApi;
            _usuarioService = usuarioApi;

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
        [HttpPost]
        public IActionResult EditarProducto(Producto _producto)
        {
            var producto = _productoService.Update(_producto.Id, _producto);
            return RedirectToAction("ProductosVendedor", "VVendedor");
        }

        public IActionResult Alimentos()
        {
            var productos = _productoService.Get();
            var lvpv = new List<VProductoVendedor>();
            foreach (var item in productos)
            {
                if(item.Categoria=="Alimentos")
                {
                    var vpv = new VProductoVendedor();
                    var vendedor = new Usuario();
                    vendedor = _usuarioService.GetId(item.IdVendedor);
                    vpv.Producto = item;
                    vpv.Usuario = vendedor;
                    lvpv.Add(vpv);
                }
            }

            return View(lvpv);

        }

        public IActionResult Productos()
        {

            var productos = _productoService.Get();
            var lvpv = new List<VProductoVendedor>();
            foreach (var item in productos)
            {
                if (item.Categoria == "Productos")
                {
                    var vpv = new VProductoVendedor();
                    var vendedor = new Usuario();
                    vendedor = _usuarioService.GetId(item.IdVendedor);
                    vpv.Producto = item;
                    vpv.Usuario = vendedor;
                    lvpv.Add(vpv);
                }
            }

            return View(lvpv);
        }

        public IActionResult Servicios()
        {

            var productos = _productoService.Get();
            var lvpv = new List<VProductoVendedor>();
            foreach (var item in productos)
            {
                if (item.Categoria == "Productos")
                {
                    var vpv = new VProductoVendedor();
                    var vendedor = new Usuario();
                    vendedor = _usuarioService.GetId(item.IdVendedor);
                    vpv.Producto = item;
                    vpv.Usuario = vendedor;
                    lvpv.Add(vpv);
                }
            }

            return View(lvpv);
        }
    }
}
