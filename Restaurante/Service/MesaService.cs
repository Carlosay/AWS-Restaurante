using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Dto;
using Restaurante.Entities;
using Restaurante.Interface;

namespace Restaurante.Service
{
    public class MesaService : IMesaService
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;
        public MesaService(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ActionResult<List<MesaListarDTO>>> GeTAll()
        {
            var mesas = await _context.Mesas
                .Include(c => c.EstadoMesa)
                .ToListAsync();

            var mesaResponse = _mapper.Map<List<MesaListarDTO>>(mesas);

            return mesaResponse;
        }
        public async Task CrearMesa([FromBody] MesaRequestDto mesa)
        {
            // Verificar si el EstadoMesaId existe en la base de datos
            Mesa? m = _context.Mesas.Where(m => m.EstadoMesaId == mesa.EstadoMesaId).FirstOrDefault();

            if (m == null)
            {
                throw new Exception("EstadoMesaId inexistente");
            }

            var nuevaMesa = _mapper.Map<Mesa>(mesa);
            _context.Mesas.Add(nuevaMesa);
            await _context.SaveChangesAsync();

        }
    }
}
