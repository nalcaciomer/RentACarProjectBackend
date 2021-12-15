using Core.Utilities.Results;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int id);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByEmail(string email);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IResult EditProfile(UserForUpdateDto user);
    }
}