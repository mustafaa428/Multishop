using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.EntityLayer.Concrate;

namespace MultiShop.Cargo.DataAccessLayer.Concrate
{
    public class CargoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1441;Database=MultiShopCargoDb;user=sa;password=PASSOWRD;TrustServerCertificate=True;");
        }

        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<CargoCustomer> CargoCustomers { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }

        public DbSet<CargoOperations> CargoOperations { get; set; }
    }
}
