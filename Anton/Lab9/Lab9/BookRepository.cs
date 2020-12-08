using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab9
{
    public class BookRepository
    {
        private SiteDbContext _siteDbContext;

        public BookRepository(SiteDbContext siteDbContext)
        {
            _siteDbContext = siteDbContext;
        }

        public List<Book> GetBooks()
        {
            return _siteDbContext.Books.ToList();
        }

        public async Task<int> AddBookAsync(string name, string author, string genre)
        {
            var car = new Book
            {
                Name = name,
                Author = author,
                Genre = genre
            };
            _siteDbContext.Books.Add(car);
            await _siteDbContext.SaveChangesAsync();
            return (from Car in _siteDbContext.Books
                    where Car.Name == name && Car.Author == author && Car.Genre == genre
                select Car).ToList()[0].Id;
        }

        public async Task UpdateBookAsync(int id, string name, string author, string genre)
        {
            var car = _siteDbContext.Books.Find(id);
            car.Name = name;
            car.Author = author;
            car.Genre = genre;
            _siteDbContext.Books.Update(car);
            await _siteDbContext.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var car = _siteDbContext.Books.Find(id);
            _siteDbContext.Books.Remove(car);
            await _siteDbContext.SaveChangesAsync();
        }
    }
}