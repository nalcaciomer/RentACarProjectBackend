﻿using System;
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

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();

        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
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

        public List<CarDetailDto> GetCarsDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(int id)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetailsByBrand(string brandName)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetailsByColor(string colorName)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetailsByBrandAndColor(string brandName, string colorName)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetailsByBrand(int id)
        {
            throw new NotImplementedException();
        }

        

        public List<CarDetailDto> GetCarsDetailsByColor(int id)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsDetailsByBrandAndColor(int brandId, int colorId)
        {
            throw new NotImplementedException();
        }
    }
}
