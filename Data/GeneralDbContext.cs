using CarRental_14665.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity;

namespace CarRental_14665.Data
{
    public class GeneralDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public GeneralDbContext(DbContextOptions<GeneralDbContext> options) : base(options) { }
        public Microsoft.EntityFrameworkCore.DbSet<Rentals> Rentals { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Category> Categories { get; set; }
    }
}
