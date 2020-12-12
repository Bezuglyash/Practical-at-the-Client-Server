using System.Collections.Generic;
using _10thLab.Models;
using Microsoft.EntityFrameworkCore;

namespace _10thLab
{
    public class TenthLabDbContext : DbContext
    {
        public TenthLabDbContext() { }

        public TenthLabDbContext(DbContextOptions<TenthLabDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cars = new List<Car>();
            cars.Add(new Car
            {
                Id = 1,
                Name = "BMW",
                Model = "X6",
                Price = 5728000
            });
            cars.Add(new Car
            {
                Id = 2,
                Name = "BMW",
                Model = "M5",
                Price = 3128000
            });
            cars.Add(new Car
            {
                Id = 3,
                Name = "Volkswagen",
                Model = "Jetta",
                Price = 1328000
            });
            modelBuilder.Entity<Car>().HasData(cars);
            base.OnModelCreating(modelBuilder);
        }
    }
}