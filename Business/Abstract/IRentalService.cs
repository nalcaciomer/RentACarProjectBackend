using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int id);
        IDataResult<List<Rental>> GetByCustomerId(int customerId);
        IDataResult<List<Rental>> GetByCarId(int carId);
        IDataResult<List<RentalDetailDto>> GetDetails();
    }
}