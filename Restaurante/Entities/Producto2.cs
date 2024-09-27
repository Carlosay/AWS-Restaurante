namespace Restaurante.Entities
{
    public class Producto2
    {
        private int stock;

        //Genero este constructor que recibe parametros 
        public Producto2(int stock) 
        {
            this.stock = stock;
        }

        public int Stock
        {
            get { return this.stock; }
            //set
            //{
            //    int resultado = this.stock - value;
            //    if (resultado < 0)
            //    {
            //        throw new Exception("No se puede descontar del stock");
            //    }
            //    this.stock += value;
            //}

        }
        public void restarProducto(int stock)
        {
            int resultado = this.stock - stock;
            if(resultado < 0)
            {
                throw new Exception("No se puede descontar del stock");
            }
            this.stock = resultado;
        }
    }
}
