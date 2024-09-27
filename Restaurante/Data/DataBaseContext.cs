using Microsoft.EntityFrameworkCore;
using Restaurante.Entities;

namespace Restaurante.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {

        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)

        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=FERNOTE\SQLEXPRESS; Database=test1; Trusted_Connection=True; TrustServerCertificate=True");

        }
        public virtual DbSet<Comanda> Comandas { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<EstadoMesa> EstadoMesa { get; set; }
        public virtual DbSet<Mesa> Mesas { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Sector> Sectores { get; set; }
        public virtual DbSet<EstadoPedido> EstadoPedido { get; set; }
    }


}
