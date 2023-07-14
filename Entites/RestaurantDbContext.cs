using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI5.Entites
{
    public class RestaurantDbContext : DbContext
    {
        private string _connectionString = "server = (LocalDb)\\MSSQLLocalDB;database = RestaurantDatabase;Trusted_Connection = true;";
        public DbSet<Restaurant> restaurants { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Dish> dishes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .HasOne(r => r.Address)
                .WithOne(r => r.Restaurant)
                .HasForeignKey<Address>(r => r.RestaurantId);
            modelBuilder.Entity<Restaurant>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<Dish>()
                .Property(d => d.Name)
                .IsRequired();
            modelBuilder.Entity<Address>()
                .Property(r => r.Street)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Address>()
                .Property(r => r.City)
                .IsRequired()
                .HasMaxLength(50);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
