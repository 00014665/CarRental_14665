using CarRental_14665.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental_14665.Data.Migrations
{
    public class CarRentalDbContext : DbContext
    {
        public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options) : base(options) { }

        public DbSet<Rentals> Rentals { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
