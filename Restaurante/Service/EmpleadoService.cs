using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Dto;
using Restaurante.Entities;
using Restaurante.Interface;

namespace Restaurante.Service
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;
        public EmpleadoService(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<EmpleadoResponseDto>> GetAllEmpleados()
        {
            var empleados = await _context.Empleados
            .Include(e => e.Rol)     
            .Include(e => e.Sector)  
            .ToListAsync();

            
            return _mapper.Map<List<EmpleadoResponseDto>>(empleados);
        }

        public async Task<ActionResult<EmpleadoResponseDto>> GetById(int idEmpleado)
        {
            var empleado = await _context.Empleados
            .Include(x => x.Rol)
            .Include (x => x.Sector)
            .FirstOrDefaultAsync(e => e.Id == idEmpleado);

            if (empleado == null)
            {
                throw new Exception("Empleado inexistente");
            }

           
            var empleadoResponse = _mapper.Map<EmpleadoResponseDto>(empleado);
            return empleadoResponse;
        }

        public async Task<ActionResult<EmpleadoResponseDto>> Create(EmpleadoRequestCreateDto empleado)
        {
            var rol = await _context.Roles.FindAsync(empleado.IdRol);
            var sector = await _context.Sectores.FindAsync(empleado.IdSector);

            // Verificar si se encontraron los roles y sectores
            if (rol == null || sector == null)
            {
                throw  new Exception("rol o sector no encontrado");
            }

            var nuevoEmpleado = _mapper.Map<Empleado>(empleado);
            nuevoEmpleado.Rol = rol; 
            nuevoEmpleado.Sector = sector; 

            _context.Empleados.Add(nuevoEmpleado);
            await _context.SaveChangesAsync();

            
            var empleadoResponse = _mapper.Map<EmpleadoResponseDto>(nuevoEmpleado);

            return empleadoResponse;
        }
    }
}
