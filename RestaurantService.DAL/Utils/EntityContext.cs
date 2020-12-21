using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RestaurantService.DAL.Entities;
using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace RestaurantService.DAL.Utils
{
    public class EntityContext : DbContext
    {
        private string _connection;
        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public EntityContext(string connection)
        {
            _connection = connection;
            
            //Database.EnsureDeleted();

            if(Database.EnsureCreated())
                Initializer.Init(this);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Ingredient>()
                .HasIndex(p => p.Name)
                .IsUnique();

            builder.Entity<Recipe>()
                .HasIndex(p => p.Name)
                .IsUnique();
        }
    }
}
