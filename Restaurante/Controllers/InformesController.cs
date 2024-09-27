using Microsoft.AspNetCore.Mvc;
using Restaurante.Dto;

namespace Restaurante.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InformesController : Controller
    {
        [HttpGet("GetIngresos")]
        public async Task<ActionResult<List<IngresoEmpleadoDto>>> GetIngresoEmpleados()
        {
            return base.Ok(new { message = "Estos son los id, los nombres, la fecha y la hora con que ingresaron los empleados" });
        }

        [HttpGet("GetOperaciones/por-sector")]
        public async Task<ActionResult<List<OperacionesPorSectorDto>>> GetOperacionesPorSector() //Opcional (DateTime? fechaInicio, DateTime? fechaFin)
        {
            return base.Ok(new { message = "Estas son la cantidad de operaciones por sector" });
        }

        [HttpGet("operaciones/por-sector-empleado")]
        public async Task<ActionResult<List<OperacionesPorSectorEmpleadoDto>>> GetOperacionesPorSectorEmpleado() //Opcional (DateTime? fechaInicio, DateTime? fechaFin)
        {
            return base.Ok(new { message = "Estos son la cantidad de operaciones realizadas en cada sector desglosada por cada empleado " });
        }

        [HttpGet("operaciones/por-empleado")]
        public async Task<ActionResult<List<OperacionesPorEmpleadoDto>>> GetOperacionesPorEmpleado() //Opcional (DateTime? fechaInicio, DateTime? fechaFin)
        {
            return base.Ok(new { message = "Estas son la cantidad de operaciones hechas por cada empleado" });
        }

        [HttpGet("GetMasVendidos")]
        public async Task<ActionResult<List<ProductosVendidosDto>>> GetProductosMasVendidos() //Opcional (DateTime? fechaInicio, DateTime? fechaFin)
        {
            return base.Ok(new { message = "Estos son los productos mas vendidos" });
        }

        [HttpGet("GetMenosVendidos")]
        public async Task<ActionResult<List<ProductosVendidosDto>>> GetProductosMenosVendidos() //Opcional (DateTime? fechaInicio, DateTime? fechaFin)
        {
            return base.Ok(new { message = "Estos son los productos menos vendidos" });
        }

        [HttpGet("pedidos/fuera-de-tiempo")]
        public async Task<ActionResult<List<PedidosFueraDeTiempoDto>>> GetPedidosFueraDeTiempo()
        {
            return base.Ok(new { message = "Estos son los pedidos que no se entregaron en el tiempo estimado" });
        }


    }
}
