using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurante.Entities
{
    public class Producto : ClaseBase
    {
        public int SectorId { get; set; }
        [ForeignKey(nameof(SectorId))]
        public Sector Sector { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; } 
        public float Precio { get; set; }

        public void ReducirStock(int cantidad)
        {
            int nuevoStock = this.Stock - cantidad;

            if(nuevoStock < 0)
            {
                throw new Exception($"No se puede reducir stock en {cantidad} ya que el stock actual es {this.Stock}");
            }
            else
            {
                this.Stock = nuevoStock;
            }
            
        }
    }

    
}
