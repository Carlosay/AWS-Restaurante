namespace Restaurante.Dto
{
    public class OperacionesPorSectorEmpleadoDto
    {
        public int IdSector { get; set; } // Identificador del sector
        public string DescripcionSector { get; set; } // Descripción del sector
        public int IdEmpleado { get; set; } // Identificador del empleado
        public string NombreEmpleado { get; set; } // Nombre del empleado
        public int CantidadOperaciones { get; set; } // Cantidad de operaciones realizadas por el empleado en el sector
    }
}
