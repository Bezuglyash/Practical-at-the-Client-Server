using System.Collections.Generic;
using EightLab;
using Microsoft.EntityFrameworkCore;

namespace NinthLab
{
    public class MySiteDbContext : DbContext
    {
        public MySiteDbContext() { }

        public MySiteDbContext(DbContextOptions<MySiteDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Bread> Breads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var list = new List<Bread>();
            list.Add(new Bread
            {
                Id = 1,
                Name = "Сдобная",
                Manufacturer = "СтельмаX",
                Filling = "-"
            });
            list.Add(new Bread
            {
                Id = 2,
                Name = "Слойка",
                Manufacturer = "СтельмаX",
                Filling = "Вишня"
            });
            list.Add(new Bread
            {
                Id = 3,
                Name = "БулкаБургер",
                Manufacturer = "СтельмаX",
                Filling = "Всё подряд"
            });
            modelBuilder.Entity<Bread>().HasData(list);
            base.OnModelCreating(modelBuilder);
        }
    }
}