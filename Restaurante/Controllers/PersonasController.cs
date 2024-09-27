using Microsoft.AspNetCore.Mvc;

namespace Restaurante.Controllers
{
    [ApiController] //
    [Route("api/[controller]")] //
    public class PersonasController : Controller
    {
        [HttpGet("saludar")] //
        public string Saludar(string? nombre)
        {
            return $"Hola mundo  {nombre}";
        }

        [HttpGet("saludar/{nombre}")] //
        public string SaludarConParametro(string nombre)
        {
            return $"Hola mundo  {nombre}";
        }

        [HttpGet("despedir")] //
        public IActionResult Despedir(string? nombre)
        {
            return base.Ok(nombre);
        }

        [HttpGet("despedir2")] //
        public IActionResult Despedir2(string? nombre)
        {
            return base.Ok(new {message = "Hola como estas", status=200});
        }

        [HttpGet("despedir3")] //
        public IActionResult Despedir3(string? nombre)
        {
            return base.NoContent();
        }

        [HttpGet("condicional")] //
        public IActionResult conIf(int edad)
        {
            if (edad < 0)
            {
                return base.BadRequest(new { message = "La edad no puede ser negativa" });
            }

            // logica del negocio
            if (edad > 17)
            {
                return base.Ok(new { message = "usted es mayor de edad" });
            }
            return base.Ok(new { message = "usted es menor de edad" });
        }



    }
}
