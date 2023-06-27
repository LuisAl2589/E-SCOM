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
        public ProductosApi _productoService;
        public ProductosController(ProductosApi productoApi)
        {
            _productoService = productoApi;
        }

        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            return _productoService.Get();
        }

        [HttpGet("{id:length(24)}")]
        public  ActionResult<Producto> GetId(string id)
        {
            var producto =  _productoService.GetId(id);
            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        [HttpPost]
        public  IActionResult Post(Producto newProducto)
        {
             _productoService.Create(newProducto);

            return CreatedAtAction(nameof(Get), new { id = newProducto.Id }, newProducto);
        }

        [HttpPut]
        public  IActionResult Update(string id, Producto productoUpdate)
        {
            var producto =  _productoService.GetId(id);

            if (producto is null)
            {
                return NotFound();
            }

            productoUpdate.Id = producto.Id;
             _productoService.Update(id, productoUpdate);

            return NoContent();
        }
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var producto =  _productoService.GetId(id);
            if (producto is null)
            {
                return NotFound();
            }
             _productoService.Delete(id);
            return NoContent();
        }
    }
}
