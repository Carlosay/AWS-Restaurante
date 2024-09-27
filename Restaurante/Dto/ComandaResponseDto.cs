using Restaurante.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.Dto
{
    public class ComandaResponseDto
    {
        public int Id { get; set; }
        public string NombreMesa { get; set; }
        public string EstadoMesaDescripcion { get; set; }
        public string NombreCliente { get; set; }
        public string CodigoComanda { get; set; }
    }
}
