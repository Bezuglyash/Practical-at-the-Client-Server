using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9thLab.Models;

namespace _9thLab.Repository
{
    public class CarRepository
    {
        private NinthLabDbContext _ninthLabDbContext;

        public CarRepository(NinthLabDbContext ninthLabDbContext)
        {
            _ninthLabDbContext = ninthLabDbContext;
        }

        public List<Car> GetCars()
        {
            return _ninthLabDbContext.Cars.ToList();
        }

        public async Task<int> AddCarAsync(string name, string model, int price)
        {
            var car = new Car
            {
                Name = name,
                Model = model,
                Price = price
            };
            _ninthLabDbContext.Cars.Add(car);
            await _ninthLabDbContext.SaveChangesAsync();
            return (from Car in _ninthLabDbContext.Cars
                where Car.Name == name && Car.Model == model && Car.Price == price
                select Car).ToList()[0].Id;
        }

        public async Task UpdateCarAsync(int id, string name, string model, int price)
        {
            var car = _ninthLabDbContext.Cars.Find(id);
            car.Name = name;
            car.Model = model;
            car.Price = price;
            _ninthLabDbContext.Cars.Update(car);
            await _ninthLabDbContext.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(int id)
        {
            var car = _ninthLabDbContext.Cars.Find(id);
            _ninthLabDbContext.Cars.Remove(car);
            await _ninthLabDbContext.SaveChangesAsync();
        }
    }
}
