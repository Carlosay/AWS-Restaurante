using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Dto;
using Restaurante.Entities;
using Restaurante.Interface;

namespace Restaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class MesasController : Controller
    {
        private readonly IMesaService _mesaService;
        public MesasController(IMesaService mesaService)
        {
            _mesaService = mesaService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<MesaListarDTO>> GeTAll()
        {
            
            var mesaResponseDto = await _mesaService.GeTAll();
            return Ok(new { Message = "Listado de mesas", Mesas = mesaResponseDto});
        }
        
        [HttpPost("Create")]
        public async Task<IActionResult> CrearMesa([FromBody] MesaRequestDto mesa)
        {
           await _mesaService.CrearMesa(mesa);
            return Ok(new {message="Se agrego una mesa"});
        }

        /*
        [HttpGet("GetById/{idMesa}")]
        public async Task<ActionResult<MesaResponseDto>> GetById(int idMesa)
        {
            return base.Ok(new { message = "Estos son los detalles de la mesa" });
        }

        [HttpPost("Update")]
        public async Task<ActionResult<MesaResponseDto>> Update(int idMesa, MesaRequestDto mesa)
        {
            return base.Ok(new { message = "Mesa actualizada" });
        }
        */
    }
}
