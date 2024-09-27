using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Dto;
using Restaurante.Entities;
using Restaurante.Interface;

namespace Restaurante.Service
{
    public class PedidoService : IPedidoService
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;
        public PedidoService(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<List<PedidoListarDTO>>> GetAllPedidos()
        {
            
            var pedidos = await _context.Pedidos
                .Include(c => c.Producto)  
                .Include(c => c.EstadoPedido)
                .Include(c => c.Producto.Sector)
                .ToListAsync();

            
            var respuesta = _mapper.Map<List<PedidoListarDTO>>(pedidos);

            return respuesta;
        }

     

        public async Task<string> CrearPedido(PedidoRequestDto pedido)
        {
            Producto? p = _context.Productos.FirstOrDefault(p => p.Id == pedido.ProductoId);
            if (p == null)
            {
                throw new Exception("Producto inexistente, no puede cargar pedido");
            }
            p.ReducirStock(pedido.Cantidad);
            _context.Productos.Update(p);

            var nuevoPedido = _mapper.Map<Pedido>(pedido);

            // Genera el código único
            nuevoPedido.CodigoPedido = GenerarCodigoUnico();

            nuevoPedido.EmpleadoModificadorId = pedido.EmpleadoId;

            _context.Pedidos.Add(nuevoPedido);
            await _context.SaveChangesAsync();

            return nuevoPedido.CodigoPedido; // Retorna el código generado
        }

        private string GenerarCodigoUnico()
        {
            // Obtén el último código en la base de datos para incrementar
            var ultimoPedido = _context.Pedidos
                .OrderByDescending(p => p.CodigoPedido)
                .FirstOrDefault();

            // Si no hay pedidos, comienza con P0001
            if (ultimoPedido == null)
            {
                return "P0001";
            }

            // Extrae el número del último código
            if (int.TryParse(ultimoPedido.CodigoPedido.Substring(1), out int ultimoNumero))
            {
                return $"P{ultimoNumero + 1:D4}"; // Incrementa el número
            }

            // Si el código no es válido, devuelve un código por defecto
            return "P0001";
        }

        public async Task ActualizarEstadoPedido(int pedidoId)
        {
            // Recuperamos el pedido desde la base de datos
            var pedido = await _context.Pedidos.FindAsync(pedidoId);
            if (pedido == null)
            {
                throw new Exception("Pedido no encontrado.");
            }

            // Recuperamos el estado actual del pedido desde la base de datos
            var estadoActual = await _context.EstadoPedido.FindAsync(pedido.EstadoId);
            if (estadoActual == null)
            {
                throw new Exception("Estado del pedido no encontrado.");
            }

            // Verificamos si el estado actual es 'Finalizado'
            if (estadoActual.Descripcion == "finalizado")
            {
                throw new Exception("No se puede actualizar el estado de un pedido finalizado.");
            }

            // Si el estado actual es 'En Preparación', actualizamos la fecha de finalización
            if (estadoActual.Descripcion == "en preparacion")
            {
                pedido.FechaFinalizacion = DateTime.Now;
            }

            // Obtener el siguiente estado (según la lógica de negocio)
            var siguienteEstado = await _context.EstadoPedido
                .OrderBy(e => e.Id)
                .FirstOrDefaultAsync(e => e.Id > pedido.EstadoId);

            if (siguienteEstado == null)
            {
                throw new Exception("No hay un siguiente estado disponible.");
            }

            // Actualizar el EstadoId del pedido con el nuevo estado
            pedido.EstadoId = siguienteEstado.Id;
            pedido.EstadoPedido = siguienteEstado;

            // Guardamos los cambios en la base de datos
            await _context.SaveChangesAsync();
        }
        public async Task<List<PedidoListarDTO>> ListarPedidosPendientesPorEmpleado(int idEmpleado)
        {
            var empleado = await _context.Empleados.Include(e => e.Sector).FirstOrDefaultAsync(e => e.Id == idEmpleado);

            if (empleado == null)
            {
                throw new Exception("Empleado no encontrado.");
            }

            var pedidosPendientes = await _context.Pedidos
                .Include(p => p.Producto)
                .Include(p => p.EstadoPedido)
                .Where(p => p.Producto.SectorId == empleado.SectorId && p.EstadoPedido.Descripcion == "pendiente")
                .ToListAsync();

            return _mapper.Map<List<PedidoListarDTO>>(pedidosPendientes);

        //    var pedidosPendientes = await _context.Pedidos
        //.Include(p => p.Producto)
        //.Where(p => p.Producto.SectorId == empleado.SectorId && p.Estado == "pendiente")
        //.ToListAsync();

        //    return Ok(pedidosPendientes);
        }

        public async Task CambiarEstadoEnPreparacion(string codigoPedido, int empleadoId, DateTime tiempoPreparacion) // Cambiar estado a en preparación
        {
            // Buscar el pedido en la base de datos
            var pedido = await _context.Pedidos.FirstOrDefaultAsync(p => p.CodigoPedido == codigoPedido);
            if (pedido == null)
            {
                throw new Exception("Pedido no encontrado");
            }

            // Obtener el estado "pendiente" (asumiendo que el ID correspondiente es 2)
            var estadoPendiente = await _context.EstadoPedido
                .FirstOrDefaultAsync(e => e.Id == 2); // Cambiar "en preparación" por el ID del estado pendiente
            if (estadoPendiente == null)
            {
                throw new Exception("Estado 'pendiente' no encontrado");
            }

            // Actualizar el estado y el tiempo estimado
            pedido.EstadoId = estadoPendiente.Id; // Asignar el nuevo EstadoId
            pedido.FechaEstimadaDeFinalizacion = tiempoPreparacion; // Asignar el tiempo estimado
            pedido.EmpleadoModificadorId = empleadoId; // Asignar el empleado que modifica

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();
        }

        public async Task CambiarEstadoListoParaServir(string codigoPedido, int empleadoId)
        {
            // Buscar el pedido en la base de datos
            var pedido = await _context.Pedidos.FirstOrDefaultAsync(p => p.CodigoPedido == codigoPedido);
            if (pedido == null)
            {
                throw new Exception("Pedido no encontrado.");
            }

            // Obtener el estado "listo para servir"
            var estadoListoParaServir = await _context.EstadoPedido
                .FirstOrDefaultAsync(e => e.Descripcion == "listo para servir");
            if (estadoListoParaServir == null)
            {
                throw new Exception("Estado 'listo para servir' no encontrado.");
            }

            // Cambiar el estado a "listo para servir"
            pedido.EstadoId = estadoListoParaServir.Id; // Cambiar a "listo para servir"
            pedido.FechaFinalizacion = DateTime.Now; // Establecer fecha de finalización

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al actualizar el pedido.", ex);
            }
        }















    }
}
