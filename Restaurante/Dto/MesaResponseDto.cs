namespace Restaurante.Dto
{
    public class MesaResponseDto
    {
        public int Id { get; set; } //Id priviene de la clase base
        public string EstadoMesa { get; set; }
        public string Nombre { get; set; } //Nombre o identificador de la mesa
    }
}
