using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Dto;
using Restaurante.Entities;
using Restaurante.Interface;
                               //En lugar de crear una instancia de EmpleadoService directamente dentro del controlador ejemplo:
                               // var empleadoService = new EmpleadoService();
                               //La inyeccion de dependencia permite que el controlador reciba una implementacion
                               //ya construida de IEmpleadoService desde un contenedor de dependencias(en este caso
                               //configurado en Program)
namespace Restaurante.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : Controller
    {

        private readonly IEmpleadoService _empleadoService; //campo privado de solo lectura de tipo IEmpleadoService,
                                                            //sirve para guardar la instancia del servicio que sera usado
                                                            //dentro del controlador

        public EmpleadosController(IEmpleadoService empleadoService) //El servicio se inyecta mediante el constructor
        {
            _empleadoService = empleadoService; //El servicio es almacenado en el campo privado
        }

        [HttpGet("GetAll")] //Ahora podemos usar _empleadoService en los metodos del controlador
        public async Task<ActionResult<List<EmpleadoResponseDto>>> GetAll()
        {
            var empleadoResponseDto = await _empleadoService.GetAllEmpleados();
            return Ok(new { message = "Estos son todos los empleados: ", Empleado = empleadoResponseDto });
        }
    
        
        [HttpGet("GetById/{idEmpleado}")]
        public async Task<ActionResult<EmpleadoResponseDto>> GetById(int idEmpleado)
        {
           var empleadoResponseDto = await _empleadoService.GetById(idEmpleado);
            return Ok(new { message = "El empleado buscado es: ", Empleado = empleadoResponseDto });
        }
        
        [HttpPost("Create")]
        public async Task<ActionResult<EmpleadoResponseDto>> Create(EmpleadoRequestCreateDto empleado)
        {
            var empleadoResponseDto = await _empleadoService.Create(empleado);
            return Ok(new { message = "Usted ha creado un nuevo empleado", Empleado = empleadoResponseDto });
        }
        /*
        [HttpPut("Update/{idEmpleado}")]
        public async Task<ActionResult<EmpleadoResponseDto>> Update(int idEmpleado, EmpleadoRequestUpdateDto empleado)
        {
            return Ok(new { message = "Usted actualizo un empleado" });
        }

        [HttpDelete("Delete/{idEmpleado}")]
        public async Task<ActionResult<bool>> DeleteByIdEmpleado(int idEmpleado)
        {
            return Ok(new { message = "Se elimino un empleado" });
        }

        [HttpPost("Entrada/{idEmpleado}")]
        public async Task<ActionResult> RegistrarEntrada(int idEmpleado)
        {
            return Ok(new { message = "Se registro la entrada" });
        }
        */
    }
}

