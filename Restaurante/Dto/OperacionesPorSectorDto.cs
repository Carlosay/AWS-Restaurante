namespace Restaurante.Dto
{
    public class OperacionesPorSectorDto
    {
        public int Id { get; set; } // Identificador del sector
        public string Descripcion { get; set; } // Descripción del sector

        //// Se supone que debo tener una tabla llammada Operaciones para calcular la cantidad de operaciones
        public int CantidadOperaciones { get; set; } // Cantidad de operaciones realizadas en el sector 
    }

}
