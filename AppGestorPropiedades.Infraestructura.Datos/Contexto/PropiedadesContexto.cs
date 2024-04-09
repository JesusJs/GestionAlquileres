
using Microsoft.EntityFrameworkCore;
using AppGestorPropiedades.Dominio.Entidades;
using Microsoft.Extensions.Configuration;
using AppGestorPropiedades.Infraestructura.Datos.Configs;

namespace AppGestorPropiedades.Infraestructura.Datos.Contexto
{
    public class PropiedadesContexto: DbContext
    {
        public DbSet<Propiedades> Propiedades { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public PropiedadesContexto()
        {
        }

        public PropiedadesContexto(DbContextOptions<PropiedadesContexto> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LOCALHOST;Initial Catalog=GestorPropiedades; User Id=prueba;Password=pruebapass;Integrated Security=true;Trust Server Certificate=true");
        }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PropiedadesConfig()); 
                modelBuilder.ApplyConfiguration(new ClientesConfig());
        }
        #endregion

    }
}
