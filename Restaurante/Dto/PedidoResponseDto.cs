namespace Restaurante.Dto
{
    public class PedidoResponseDto
    {
        public string Producto { get; set; }
        public int CodigoComanda { get; set; } //referente a la entidad Comanda
        public String Estado { get; set; } //referente a la entidad EstadoMesa 
        public int Cantidad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaFinalizacion { get; set; }

        public string CodigoPedido { get; set; }    


    }
}
