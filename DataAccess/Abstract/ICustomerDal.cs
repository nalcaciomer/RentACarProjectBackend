using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
        List<CustomerDetailDto> GetDetails(Expression<Func<CustomerDetailDto, bool>> filter = null);
    }
}