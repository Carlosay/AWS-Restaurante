namespace Restaurante.Dto
{
    public class OperacionesPorEmpleadoDto
    {
        public int IdEmpleado { get; set; } // Identificador del empleado
        public string NombreEmpleado { get; set; } // Nombre del empleado
        public int CantidadOperaciones { get; set; } // Cantidad total de operaciones realizadas por el empleado
    }
}
