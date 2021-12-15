using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetByBrandId(int brandId);
        IDataResult<List<Car>> GetByColorId(int colorId);
        IDataResult<List<Car>> GetByBrandIdAndColorId(int brandId, int colorId);
        IDataResult<List<Car>> GetByDailyPrice(int min, int max);
        IDataResult<List<CarDetailDto>> GetDetails();
        IDataResult<List<CarDetailDto>> GetDetailsById(int id);
        IDataResult<List<CarDetailDto>> GetDetailsByBrandName(string brandName);
        IDataResult<List<CarDetailDto>> GetDetailsByColorName(string colorName);
        IDataResult<List<CarDetailDto>> GetDetailsByBrandNameAndColorName(string brandName, string colorName);
        IDataResult<List<CarDetailDto>> GetDetailsByDailyPrice(int min, int max);
    }
}