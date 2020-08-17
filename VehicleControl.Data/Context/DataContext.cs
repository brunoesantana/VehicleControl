using Microsoft.EntityFrameworkCore;
using VehicleControl.Domain;

namespace VehicleControl.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Modelo> Modelo { get; set; }
        public DbSet<Anuncio> Anuncio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer("Server=BRUNOPC\\SQLEXPRESS;Database=vehiclecontrol;Trusted_Connection=True");
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
