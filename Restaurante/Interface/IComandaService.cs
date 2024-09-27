using Microsoft.AspNetCore.Mvc;
using Restaurante.Dto;

namespace Restaurante.Interface
{
    public interface IComandaService
    {
        public Task CrearComanda(ComandaRequestDto comanda);
    }
}
