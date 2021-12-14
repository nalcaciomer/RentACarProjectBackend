using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private ICarService _carService;

        public CarImageManager(ICarImageDal carImageDal, ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarsImagesListed);
        }

        [CacheAspect]
        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i=> i.Id == carImageId), Messages.CarImageListed);
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarImageNull(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId).Data);
        }

        public IDataResult<List<CarImageDto>> GetDtoByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarImageNull(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImageDto>>(result.Message);
            }

            var carImage = CheckIfCarImageNull(carId).Data;
            var carDetails = _carService.GetCarDetails(carId).Data;
            List<CarImageDto> carImageDto = new List<CarImageDto>();

            for (int i = 0; i < carImage.Count; i++)
            {
                var imageDto = new CarImageDto
                {
                    Id = carId, BrandName = carDetails[0].BrandName, ColorName = carDetails[0].ColorName,
                    DailyPrice = carDetails[0].DailyPrice, Description = carDetails[0].Description,
                    ModelYear = carDetails[0].ModelYear, ImagePath = carImage[i].ImagePath,
                    UploadDate = carImage[i].UploadDate
                };
                carImageDto.Add(imageDto);
            }


            return new SuccessDataResult<List<CarImageDto>>(carImageDto);
        }

        [SecuredOperation("carImages.add,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(IFormFile file,CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImagesLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.UploadDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [SecuredOperation("carImages.update,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImagesLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;

            carImage.ImagePath = FileHelper.Update(oldPath, file);
            carImage.UploadDate = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        [SecuredOperation("carImages.delete,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        private IResult CheckCarImagesLimitExceeded(int carId)
        {
            var carImagesCount = _carImageDal.GetAll(i=> i.CarId == carId).Count;
            if (carImagesCount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNull(int carId)
        {
            try
            {
                string path = @"\uploads/defaultCar.jpg";
                var result = _carImageDal.GetAll(i => i.CarId == carId).Any();
                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>
                    {
                        new CarImage {CarId = carId, ImagePath = path, UploadDate = DateTime.Now}
                    };
                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<CarImage>>(e.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == carId));
        }
    }
}
