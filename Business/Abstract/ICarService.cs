using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandId(int id);
        IDataResult<List<Car>> GetAllByColorId(int id);
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        IDataResult<List<CarDetailDto>> GetCarsDetails();
        IDataResult<List<CarDetailDto>> GetCarDetails(int id);
        IDataResult<List<CarDetailDto>> GetCarsDetailsByBrand(int id);
        IDataResult<List<CarDetailDto>> GetCarsDetailsByColor(int id);
        IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandAndColor(int brandId, int colorId);
        IDataResult<Car> GetById(int id);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);


        
    }
}
