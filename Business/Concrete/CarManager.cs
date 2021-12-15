using System.Collections.Generic;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        //[SecuredOperation("car.add,admin")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        //[SecuredOperation("car.update,admin")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        //[SecuredOperation("car.delete,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id), Messages.CarListed);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id), Messages.CarsListed);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), Messages.CarsListed);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetByBrandIdAndColorId(int brandId, int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId && c.ColorId == colorId), Messages.CarsListed);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetByDailyPrice(int min, int max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max), Messages.CarsListed);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetDetails(), Messages.CarsDetailsListed);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetDetailsById(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetDetails(c => c.Id == id), Messages.CarsDetailsListed);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetDetailsByBrandName(string brandName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetDetails(c => c.BrandName == brandName), Messages.CarsDetailsListed);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetDetailsByColorName(string colorName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetDetails(c => c.ColorName == colorName), Messages.CarsDetailsListed);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetDetailsByBrandNameAndColorName(string brandName, string colorName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetDetails(c => c.BrandName == brandName && c.ColorName == colorName), Messages.CarsDetailsListed);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetDetailsByDailyPrice(int min, int max)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetDetails(c => c.DailyPrice >= min && c.DailyPrice <= max), Messages.CarsDetailsListed);
        }
    }
}
