using ESCOM_merce.Models;
using ESCOM_merce.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ESCOM_merce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        public VentasApi _ventasService;
        public VentasController(VentasApi ventasApi)
        {
            _ventasService = ventasApi;
        }

        [HttpGet]
        public ActionResult<List<Ventas>> Get()
        {
            return _ventasService.Get();
        }
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Ventas>> GetId(string id)
        {
            var venta = await _ventasService.GetId(id);
            if (venta == null)
            {
                return NotFound();
            }

            return venta;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Ventas newVenta)
        {
            await _ventasService.Create(newVenta);

            return CreatedAtAction(nameof(Get), new { id = newVenta.Id }, newVenta);
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, Ventas ventaUpdate)
        {
            var venta = await _ventasService.GetId(id);

            if (venta is null)
            {
                return NotFound();
            }

            ventaUpdate.Id = venta.Id;
            await _ventasService.Update(id, ventaUpdate);

            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var producto = await _ventasService.GetId(id);
            if (producto is null)
            {
                return NotFound();
            }
            await _ventasService.Delete(id);
            return NoContent();
        }
    }
}
