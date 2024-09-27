using Restaurante.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.Entities
{
    public class Pedido:ClaseBase
    {
        private DataBaseContext _context;
        public Pedido()
        {
            this.FechaCreacion = DateTime.Now;
            this.EstadoId = 1;  // ID del estado "pendiente"
            
        }
        public int ProductoId { get; set; }
        [ForeignKey(nameof(ProductoId))]
        public Producto Producto { get; set; }

        public int ComandaId { get; set; }
        [ForeignKey(nameof(ComandaId))]
        public Comanda Comanda { get; set; }

        public int EstadoId { get; set; }
        [ForeignKey(nameof(EstadoId))]
        public EstadoPedido EstadoPedido { get; set; } 
        public int Cantidad { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaFinalizacion { get; set; }

        public DateTime? FechaEstimadaDeFinalizacion { get; set; }

        public string CodigoPedido { get; set; } // Nueva propiedad para el código
        public int EmpleadoModificadorId { get; set; } //Nueva Propiedad para guardar empleado que realiza cambios

    }

    
}
