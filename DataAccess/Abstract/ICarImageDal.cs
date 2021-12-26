using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarImageDal : IEntityRepository<CarImage>
    {
        List<CarImageDto> GetDetails(Expression<Func<CarImageDto, bool>> filter = null);
    }
}
