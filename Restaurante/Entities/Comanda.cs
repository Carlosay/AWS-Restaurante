using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.Entities
{
    public class Comanda : ClaseBase
    {
        // Propiedad de clave foránea explícita para Mesa
        public int MesaId { get; set; }

        [ForeignKey(nameof(MesaId))]
        public Mesa Mesa { get; set; }

        public string nombreCliente { get; set; }
        public string codigoComanda { get; set; } // Se agregó código único alfanumérico de 5 caracteres
    }
}
