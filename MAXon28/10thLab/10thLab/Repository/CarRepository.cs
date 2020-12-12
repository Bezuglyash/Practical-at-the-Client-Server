using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _10thLab.Models;

namespace _10thLab.Repository
{
    public class CarRepository
    {
        private TenthLabDbContext _tenthLabDbContext;

        public CarRepository(TenthLabDbContext ninthLabDbContext)
        {
            _tenthLabDbContext = ninthLabDbContext;
        }

        public List<Car> GetCars()
        {
            return _tenthLabDbContext.Cars.ToList();
        }

        public async Task<int> AddCarAsync(string name, string model, int price)
        {
            var car = new Car
            {
                Name = name,
                Model = model,
                Price = price
            };
            _tenthLabDbContext.Cars.Add(car);
            await _tenthLabDbContext.SaveChangesAsync();
            return (from Car in _tenthLabDbContext.Cars
                where Car.Name == name && Car.Model == model && Car.Price == price
                select Car).ToList()[0].Id;
        }

        public async Task UpdateCarAsync(int id, string name, string model, int price)
        {
            var car = _tenthLabDbContext.Cars.Find(id);
            car.Name = name;
            car.Model = model;
            car.Price = price;
            _tenthLabDbContext.Cars.Update(car);
            await _tenthLabDbContext.SaveChangesAsync();
        }

        public async Task DeleteCarAsync(int id)
        {
            var car = _tenthLabDbContext.Cars.Find(id);
            _tenthLabDbContext.Cars.Remove(car);
            await _tenthLabDbContext.SaveChangesAsync();
        }
    }
}
