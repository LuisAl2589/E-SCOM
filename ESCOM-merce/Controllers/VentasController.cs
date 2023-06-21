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
        public VentasApi _ventasApi;
        public VentasController(VentasApi ventasApi)
        {
            _ventasApi = ventasApi;
        }

        [HttpGet]
        public ActionResult<List<Ventas>> Get()
        {
            return _ventasApi.Get();
        }
    }
}
