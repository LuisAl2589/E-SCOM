using ESCOM_merce.Services;
using Microsoft.AspNetCore.Mvc;
using ESCOM_merce.Models;
using System.Globalization;
using System.Security.Claims;

namespace ESCOM_merce.Controllers
{
    public class VVentasController : Controller
    {
        public CarritoApi _carritoService;
        public ProductosApi _productoService;
        public VentasApi _ventaService;
        public UsuariosApi _usuarioService;



        public VVentasController(CarritoApi carritoApi, ProductosApi productoApi, VentasApi ventaApi, UsuariosApi usuarioApi)
        {
            _carritoService = carritoApi;
            _productoService = productoApi;
            _ventaService = ventaApi;
            _usuarioService = usuarioApi;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PedidosClientes()
        {
            var pedidos = new List<VPedidoUsuario>();
            var ventas = new List<Ventas>();
            ventas = _ventaService.GetIdVendedor(User.FindFirstValue(ClaimTypes.NameIdentifier));

            foreach (var venta in ventas)
            {
                var cliente = new Usuario();
                var pedidoUsuario = new VPedidoUsuario();
                cliente = _usuarioService.GetId(venta.IdCliente);
                pedidoUsuario.Usuario = cliente;
                pedidoUsuario.Venta = venta;
                pedidos.Add(pedidoUsuario);
            }


            return View(pedidos);
        }

        public IActionResult Pedidos()
        {
            var pedidos = new List<VPedidoUsuario>();
            var ventas = new List<Ventas>();
            ventas = _ventaService.GetIdCliente(User.FindFirstValue(ClaimTypes.NameIdentifier));

            foreach (var venta in ventas)
            {
                var vendedor = new Usuario();
                var pedidoUsuario = new VPedidoUsuario();
                 vendedor = _usuarioService.GetId(venta.IdVendedor);
                pedidoUsuario.Usuario = vendedor;
                pedidoUsuario.Venta = venta;
                pedidos.Add(pedidoUsuario);
            }

            
            return View(pedidos);
        }

        public IActionResult RegistroVenta(string _idCarrito)
        {
            var carrito = _carritoService.GetId(_idCarrito);
            return View(carrito);
        }

        [HttpPost]
        public IActionResult RegistrarVenta(string _idCarrito, string lugar, string descripcion, string fechaEntrega, string horaEntrega)
        {
            var carrito = _carritoService.GetId(_idCarrito);
            
                var ventaN = new Ventas();
                ventaN.IdVendedor = carrito.IdVendedor;
                ventaN.IdCliente = carrito.IdCliente;
                var productosCantidad = new List<ProductoCantidad>();
                var Total = (decimal)0;

                foreach (var detalle in carrito.Detalles)
                {
                    var productoCantidad = new ProductoCantidad();

                    var producto = new Producto();
                    producto = _productoService.GetId(detalle.IdProducto);
                    productoCantidad.Producto = producto;
                    productoCantidad.Cantidad = detalle.Unidades;
                    Total = Total + (producto.Costo * detalle.Unidades);
                    productosCantidad.Add(productoCantidad);
                }
            ventaN.Detalle = productosCantidad;
            string fechaHora = fechaEntrega+"T"+horaEntrega;
            DateTime fecha;
                ventaN.Total = (decimal)Total;
            DateTime.TryParseExact(fechaHora, "yyyy-MM-ddTHH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha);
                ventaN.FechaEntrega = fecha;
                ventaN.FechaPedido = DateTime.Now;
                var lugarO = new Lugar();
                lugarO.Descripcion = descripcion;
                lugarO.Nombre = lugar;
                lugarO.Link = "https://www.google.com/search?client=opera-gx&hs=52Q&tbs=lf:1,lf_ui:2&tbm=lcl&sxsrf=APwXEdffK2C0eNz2IzZDoKdycLBqAXcOgA:1687767708817&q=escom&rflfq=1&num=10&rldimm=12559774557345238341&ved=2ahUKEwiBv_vVwOD_AhXUlWoFHZ0RDjQQu9QIegQIGBAL#rlfi=hd:;si:4603055391739808457,l,CgVlc2NvbUifnLE3WhEQABgAIgVlc2NvbSoECAIQAJIBEnBvbHl0ZWNobmljX3NjaG9vbKoBLRABMh4QASIau-GafBR1RJtfy6_ES450IUQiFy_jXfFoSNcyCRACIgVlc2NvbQ;mv:[[19.5088314,-99.10089699999999],[19.4525629,-99.14976469999999]]";
                ventaN.LugarVenta = lugarO;
                ventaN.Completado = false;

            _ventaService.Create(ventaN);
            _carritoService.Delete(_idCarrito);

            return RedirectToAction("Pedidos","VVentas");
        }
    }
}
