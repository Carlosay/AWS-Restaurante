using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurante.Data;
using Restaurante.Dto;
using Restaurante.Entities;
using Restaurante.Interface;

namespace Restaurante.Service
{
    public class ComandaService : IComandaService
    {
        private readonly DataBaseContext _context;
        private readonly IMapper _mapper;
        public ComandaService(DataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CrearComanda(ComandaRequestDto comanda)
        {
            var nuevaComanda = _mapper.Map<Comanda>(comanda);

            // Guardamos la nueva comanda en la base de datos
            _context.Comandas.Add(nuevaComanda);
            await _context.SaveChangesAsync();

            // Obtenemos la información relacionada con la mesa
            var mesaConEstado = await _context.Mesas
                .Include(x => x.EstadoMesa)
                .FirstOrDefaultAsync(m => m.Id == nuevaComanda.MesaId);

            
        }
    }
}
