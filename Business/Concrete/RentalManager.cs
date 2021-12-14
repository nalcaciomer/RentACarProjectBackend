using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r=> r.CarId == carId));
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAllByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r=> r.CustomerId == customerId));
        }

        [CacheAspect]
        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=> r.Id == rentalId));
        }

        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            IResult result =  BusinessRules.Run(CheckCarAvailable(rental));
            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        [SecuredOperation("admin,user")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckCarAvailable(rental));
            if (result != null)
            {
                return result;
            }

            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalDetailsListed);
        }

        private IResult CheckCarAvailable(Rental rental)
        {
            var result = _rentalDal.Get(r => (r.CarId == rental.CarId && r.RentDate > rental.ReturnDate && r.ReturnDate == null) || (r.CarId == rental.CarId && rental.RentDate < r.ReturnDate));
            if (result != null)
            {
                return new ErrorResult(Messages.TheCarIsInUse);
            }

            return new SuccessResult(Messages.RentalSuccessful);
        }
    }
}
