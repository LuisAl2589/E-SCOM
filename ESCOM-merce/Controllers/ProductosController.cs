using ESCOM_merce.Models;
using ESCOM_merce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESCOM_merce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        public ProductosApi _productoApi;
        public ProductosController(ProductosApi productoApi)
        {
            _productoApi = productoApi;
        }

        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            return _productoApi.Get();
        }
    }
}
