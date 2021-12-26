using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImage carImage);
        IResult Update(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IDataResult<List<CarImageDto>> GetDetails();
        IDataResult<List<CarImageDto>> GetDetailsById(int id);
        IDataResult<List<CarImageDto>> GetDetailsByCarId(int carId);

    }
}