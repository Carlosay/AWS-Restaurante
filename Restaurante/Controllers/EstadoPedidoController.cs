using Microsoft.AspNetCore.Mvc;

namespace Restaurante.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadoPedidoController : Controller
    {
        [HttpGet("{codigoMesa}/{codigoPedido}")]
        public async Task<ActionResult> GetEstadoPedido(string codigoMesa, string codigoPedido)
        {
            return Ok(new { message = "Este es el estado de su pedido" });
        }
    }
}
