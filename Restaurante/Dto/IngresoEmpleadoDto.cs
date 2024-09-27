namespace Restaurante.Dto
{
    public class IngresoEmpleadoDto
    {
        public int EmpleadoId { get; set; } // Identificador del empleado que ingresa
        public DateTime FechaIngreso { get; set; } // Fecha y hora de ingreso al sistema
        public int? IdSector { get; set; } // (Opcional) Identificador del sector al que pertenece el empleado durante el ingreso
        public int? IdRol { get; set; } // (Opcional) Identificador del rol del empleado durante el ingreso
    }

}
