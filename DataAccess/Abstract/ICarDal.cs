using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarsDetails();
        List<CarDetailDto> GetCarDetails(int id);
        List<CarDetailDto> GetCarsDetailsByBrand(int id);
        List<CarDetailDto> GetCarsDetailsByColor(int id);
        List<CarDetailDto> GetCarsDetailsByBrandAndColor(int brandId, int colorId);
    }
}
