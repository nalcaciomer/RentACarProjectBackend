using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.Id
                    join clr in context.Colors on c.ColorId equals clr.Id
                    select new CarDetailDto()
                    {
                        Id = c.Id,
                        BrandName = b.Name,
                        ColorName = clr.Name,
                        ModelYear = c.ModelYear,
                        DailyPrice = c.DailyPrice,
                        Description = c.Description
                    };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}