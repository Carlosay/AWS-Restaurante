namespace Restaurante.Dto
{
    public class PedidosFueraDeTiempoDto
    {
        public int IdPedido { get; set; } // Identificador del pedido
        public string NombreCliente { get; set; } // Nombre del cliente que realizó el pedido
        public string NombreProducto { get; set; } // Nombre del producto solicitado en el pedido
        public int Cantidad { get; set; } // Cantidad de producto solicitado
        public DateTime FechaCreacion { get; set; } // Fecha y hora en que se creó el pedido
        public DateTime FechaEstimadaFinalizacion { get; set; } // Fecha estimada de finalización del pedido
        public DateTime FechaRealFinalizacion { get; set; } // Fecha real de finalización del pedido
        public TimeSpan TiempoRetraso { get; set; } // Tiempo de retraso del pedido
    }

}
