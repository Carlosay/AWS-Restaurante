using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Dto;
using Restaurante.Entities;
using Restaurante.Interface;
using System.ComponentModel.DataAnnotations;

namespace Restaurante.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : Controller
    {
        private readonly IPedidoService _pedidoService;
        private readonly DataBaseContext _context;
        public PedidosController(IPedidoService pedidoService, DataBaseContext context)
        {
            _pedidoService = pedidoService;
            _context = context;
        }

        [HttpGet("GetAllPedidos")]
        public async Task<ActionResult<List<PedidoRequestDto>>> GetAllPedidos()
        {
            var pedidosResponseDto = await _pedidoService.GetAllPedidos();
            return Ok(new { message = "Estos son todos los pedidos", Pedido = pedidosResponseDto });
        }

        [HttpPost("create")]
        public async Task<IActionResult> CrearPedido(PedidoRequestDto pedido)
        {

            if (pedido.EmpleadoId <= 0) // Validar que el EmpleadoId sea válido
            {
                return BadRequest(new { message = "El Empleado es obligatorio." });
            }

            var codigoGenerado = await _pedidoService.CrearPedido(pedido);
            return Ok(new { message = "Ha creado un nuevo pedido", codigoPedido = codigoGenerado });
        }






      //  [HttpPost("UpdateEstadoPedido")]
    //    public async Task<IActionResult> ActualizarEstado(int id)
     /// <summary>
     ///   {
     /// </summary>
     /// <param name=""></param>
     /// <returns></returns>
      //      await _pedidoService.ActualizarEstadoPedido(id);
      //      return Ok("Estado del pedido actualizado.");
      //  }

        

        [HttpGet("pendientes/empleado/{idEmpleado}")]
        public async Task<ActionResult<List<PedidoListarDTO>>> ListarPedidosPendientesPorEmpleado(int idEmpleado)
        {
            try
            {
                var pedidosPendientes = await _pedidoService.ListarPedidosPendientesPorEmpleado(idEmpleado);
                return Ok(pedidosPendientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("cambiarEstadoEnPreparacion/{CodigoPedido}")]
        public async Task<ActionResult> CambiarEstadoEnPreparacion(string CodigoPedido, [FromQuery] int empleadoId, DateTime tiempoPreparacion)
        {
            try
            {
                await _pedidoService.CambiarEstadoEnPreparacion(CodigoPedido, empleadoId, tiempoPreparacion);
                return Ok("Estado cambiado a 'en preparación' y tiempo estimado actualizado."); // Mensaje de éxito
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message); // Retorna el mensaje de error en caso de que falle
            }
        }


        [HttpPost("cambiarEstadoListoParaServir/{CodigoPedido}")]
        public async Task<ActionResult> CambiarEstadoListoParaServir(string CodigoPedido, int empleadoId)
        {
            try
            {
                await _pedidoService.CambiarEstadoListoParaServir(CodigoPedido, empleadoId);
                return Ok("Estado cambiado a 'listo para servir'.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
