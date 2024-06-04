using Microsoft.EntityFrameworkCore;

namespace JewelryShop.GemPrice.Models
{
    public class AppDBContext : DbContext
    {
        public virtual DbSet<Gem> Gems { get; set; } = null!;
        public virtual DbSet<Metal> Metals { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyDB"));
            }
        }
    }
}
