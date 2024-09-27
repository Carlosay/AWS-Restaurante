using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.Entities
{
    public class Mesa : ClaseBase
    {
        // Propiedad de clave foránea explícita para EstadoMesa
        public int EstadoMesaId { get; set; }

        [ForeignKey(nameof(EstadoMesaId))]
        public EstadoMesa? EstadoMesa{ get; set; }

        public string Nombre { get; set; }
    }
}


// El enunciado dice que las mesas tienen un codigo de identificador unico, pero en el diagrama de base de datos no aparece ese atributo