using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 1000, ModelYear = 2021, Description = "03.01.2021 tarihine kadar kiralanmıştır."},
                new Car{Id = 2, BrandId = 1, ColorId = 2, DailyPrice = 900, ModelYear = 2020, Description = "03.01.2021 tarihine kadar kiralanmıştır."},
                new Car{Id = 3, BrandId = 2, ColorId = 2, DailyPrice = 900, ModelYear = 2021, Description = "06.01.2021 tarihine kadar kiralanmıştır."},
                new Car{Id = 4, BrandId = 3, ColorId = 3, DailyPrice = 2000, ModelYear = 2021, Description = "02.01.2021 tarihine kadar kiralanmıştır."},
                new Car{Id = 5, BrandId = 4, ColorId = 4, DailyPrice = 1250, ModelYear = 2021, Description = "05.01.2021 tarihine kadar kiralanmıştır."},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c=> c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();

        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
