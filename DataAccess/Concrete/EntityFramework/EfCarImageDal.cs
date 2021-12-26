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
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, CarRentalContext>, ICarImageDal
    {
        public List<CarImageDto> GetDetails(Expression<Func<CarImageDto, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from ci in context.CarImages
                             join c in context.Cars on ci.CarId equals c.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join clr in context.Colors on c.ColorId equals clr.Id

                             select new CarImageDto()
                             {
                                 Id = c.Id,
                                 BrandName = b.Name,
                                 ColorName = clr.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ImagePath = ci.ImagePath,
                                 UploadDate = ci.UploadDate
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}