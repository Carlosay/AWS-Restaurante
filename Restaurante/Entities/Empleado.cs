using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.Entities
{
    public class Empleado : ClaseBase
    {
        public int SectorId { get; set; }
        [ForeignKey(nameof(SectorId))]
        public Sector Sector { get; set; }

        public int RolId { get; set; }
        [ForeignKey(nameof(RolId))]
        public Rol Rol { get; set; }

        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }

    }

}
