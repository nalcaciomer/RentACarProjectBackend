using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 300, Description = "First Car", ModelYear = 2022},
                new Car{Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 400, Description = "Second Car", ModelYear = 2022},
                new Car{Id = 3, BrandId = 3, ColorId = 3, DailyPrice = 500, Description = "Third Car", ModelYear = 2022}
            };
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

        public void Update(Car entity)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == entity.Id);
            carToUpdate.BrandId = entity.BrandId;
            carToUpdate.ColorId = entity.ColorId;
            carToUpdate.DailyPrice = entity.DailyPrice;
            carToUpdate.Description = entity.Description;
            carToUpdate.ModelYear = entity.ModelYear;
        }

        public void Delete(Car entity)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == entity.Id);

            _cars.Remove(carToDelete);
        }

        public List<CarDetailDto> GetDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
