using Microsoft.AspNetCore.Mvc;
using Restaurante.Dto;

namespace Restaurante.Interface
{
    public interface IEmpleadoService
    {
        public Task<List<EmpleadoResponseDto>> GetAllEmpleados();

        public Task<ActionResult<EmpleadoResponseDto>> GetById(int idEmpleado);

        public Task<ActionResult<EmpleadoResponseDto>> Create(EmpleadoRequestCreateDto empleado);
    }
}
