using ESCOM_merce.Models;
using ESCOM_merce.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Security.Claims;

namespace ESCOM_merce.Controllers
{
    public class VCarritoController : Controller
    {
        public CarritoApi _carritoService;
        public ProductosApi _productoService;

        public VCarritoController(CarritoApi carritoApi, ProductosApi productoApi)
        {
            _carritoService = carritoApi;
            _productoService = productoApi;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VerCarrito()
        {
            var carritos = _carritoService.CarritosCliente(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var carritosProductos = new List<CarritoProducto>();
            foreach (var carro in carritos)
            {
                var carroProducto = new CarritoProducto();
                carroProducto.Carro = carro;
                var productosCant = new List<ProductoCantidad>();
                foreach (var detalle in carro.Detalles)
                {
                    var productoCantidad = new ProductoCantidad();
                    productoCantidad.Producto = _productoService.GetId(detalle.IdProducto);
                    productoCantidad.Cantidad = detalle.Unidades;
                    productosCant.Add(productoCantidad);
                }

                carroProducto.Productos = productosCant;
                carritosProductos.Add(carroProducto);
            }

            return View(carritosProductos);
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(string _idCliente, string _idVendedor, string _idProducto, int cantidad)
        {

            DetalleVenta detalle = new DetalleVenta();
            detalle.IdProducto = _idProducto;
            detalle.Unidades = cantidad;
            var carro = _carritoService.AgregarCarrito(_idCliente,_idVendedor,detalle);
            
            if (carro != null)
            {
                return RedirectToAction("VerCarrito", "VCarrito");
            }
            else
            {

                return RedirectToAction("VerCarrito", "VCarrito");
            }

        }

        
    }
}
