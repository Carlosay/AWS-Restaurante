namespace Restaurante.Dto
{
    public class PedidoListarDTO
    {
        public int Id { get; set; }
        public string Producto { get; set; } 
        public int Cantidad { get; set; }
        public string estadoPedido { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public DateTime? FechaEstimadaDeFinalizacion { get; set; }
        public string TiempoTranscurrido => this.ObtenerTiempoRestanteOExcedente();
        public string Sector { get; set; }

        private string ObtenerTiempoRestanteOExcedente()
        {
            if (this.FechaEstimadaDeFinalizacion != null)
            {

                DateTime comparacion = this.FechaFinalizacion is null ? DateTime.Now : this.FechaFinalizacion.Value;

                TimeSpan diferencia = this.FechaEstimadaDeFinalizacion.Value - comparacion;

                if (diferencia.TotalSeconds > 0)
                {

                    return $"Tiempo restante: {this.FromateaTiempo(diferencia)}";
                }
                return $"Tiempo excedido: {this.FromateaTiempo(diferencia.Negate())}";
            }

            return "No hay fecha estimada de finalización.";
        }
        private string FromateaTiempo(TimeSpan tiempo)
        {
            return $"{tiempo.Days} días, {tiempo.Hours} horas, {tiempo.Minutes} minutos";
        }

        public string CodigoPedido { get; set; }
    }

}
