using Libreria.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Libreria.Models.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=localhost;Initial catalog=libreria;User Id=paradigmi;Password=paradigmi;TrustServerCertificate=True;Trusted_Connection=True;", options =>
            {
                options.EnableRetryOnFailure();
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);

        }
    }
}
