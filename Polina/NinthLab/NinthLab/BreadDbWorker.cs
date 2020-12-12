using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinthLab
{
    public class BreadDbWorker
    {
        private MySiteDbContext _mySiteDbContext;

        public BreadDbWorker(MySiteDbContext mySiteDbContext)
        {
            _mySiteDbContext = mySiteDbContext;
        }

        public List<Bread> GetBreads()
        {
            return _mySiteDbContext.Breads.ToList();
        }

        public async Task<int> AddBreadAsync(string name, string manufacturer, string filling)
        {
            var bread = new Bread
            {
                Name = name,
                Manufacturer = manufacturer,
                Filling = filling
            };
            _mySiteDbContext.Breads.Add(bread);
            await _mySiteDbContext.SaveChangesAsync();
            return (from Bread in _mySiteDbContext.Breads
                    where Bread.Name == name && Bread.Manufacturer == manufacturer && Bread.Filling == filling
                select Bread).ToList()[0].Id;
        }

        public async Task UpdateBreadAsync(int id, string name, string manufacturer, string filling)
        {
            var bread = _mySiteDbContext.Breads.Find(id);
            bread.Name = name;
            bread.Manufacturer = manufacturer;
            bread.Filling = filling;
            _mySiteDbContext.Breads.Update(bread);
            await _mySiteDbContext.SaveChangesAsync();
        }

        public async Task DeleteBreadAsync(int id)
        {
            var bread = _mySiteDbContext.Breads.Find(id);
            _mySiteDbContext.Breads.Remove(bread);
            await _mySiteDbContext.SaveChangesAsync();
        }
    }
}
