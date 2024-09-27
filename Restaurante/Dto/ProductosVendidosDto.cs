namespace Restaurante.Dto
{
    public class ProductosVendidosDto
    { 
        public int IdProducto { get; set; } // Identificador del producto
        public string NombreProducto { get; set; } // Nombre del producto
        public int CantidadVendida { get; set; } // Cantidad total de veces que el producto fue vendido
        public string CategoriaProducto { get; set; } // Categoría del producto (opcional)
    }

}
