﻿using System.Collections.Generic;
using Lab10.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab10
{
    public class SiteDbContext : DbContext
    {
        public SiteDbContext() { }

        public SiteDbContext(DbContextOptions<SiteDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var listBooks = new List<Book>();
            listBooks.Add(new Book
            {
                Id = 1,
                Name = "Дубровский",
                Author = "А. С. Пушкин",
                Genre = "Роман"
            });
            listBooks.Add(new Book
            {
                Id = 2,
                Name = "Тарас Бульба",
                Author = "Н. В. Гоголь",
                Genre = "Повесть"
            });
            listBooks.Add(new Book
            {
                Id = 3,
                Name = "Дети капитана Гранта",
                Author = "Ж. Верн",
                Genre = "Приключенческий роман"
            });
            modelBuilder.Entity<Book>().HasData(listBooks);
            base.OnModelCreating(modelBuilder);
        }
    }
}