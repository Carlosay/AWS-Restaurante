using Microsoft.AspNetCore.Mvc;
using Restaurante.Dto;

namespace Restaurante.Interface
{
    public interface IMesaService
    {
        public Task<ActionResult<List<MesaListarDTO>>> GeTAll();
        public Task CrearMesa([FromBody] MesaRequestDto mesa);
    }
}
