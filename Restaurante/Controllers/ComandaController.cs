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
    public class ComandaController : Controller
    {
        private readonly IComandaService _comandaService;
        public ComandaController(IComandaService comandaService)
        {
            _comandaService = comandaService;
        }
       
        [HttpPost]
        public async Task<IActionResult> CrearComanda(ComandaRequestDto comanda)
        {
            await _comandaService.CrearComanda(comanda);
            return Ok(new { message = "Se creo una nueva comanda" });

        }
    }
}
