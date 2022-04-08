using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IOperationClaimService
    {
        IResult Add(OperationClaim operationClaim);
        IResult Update(OperationClaim operationClaim);
        IResult Delete(OperationClaim operationClaim);
        IDataResult<List<OperationClaim>> GetAll();
        IDataResult<OperationClaim> GetById(int id);
        IDataResult<OperationClaim> GetByOperationClaimName(string operationClaimName);
    }
}
