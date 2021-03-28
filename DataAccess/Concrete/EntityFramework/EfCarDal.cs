using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.Id
                    join clr in context.Colors
                        on c.ColorId equals clr.Id
                    select new CarDetailDto { Id = c.Id, BrandName = b.Name, ColorName = clr.Name, ModelYear = c.ModelYear,DailyPrice = c.DailyPrice, Description = c.Description};
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                    where c.Id == id
                    join b in context.Brands
                        on c.BrandId equals b.Id
                    join clr in context.Colors
                        on c.ColorId equals clr.Id
                    select new CarDetailDto { Id = c.Id, BrandName = b.Name, ColorName = clr.Name, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetailsByBrand(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.Id
                    join clr in context.Colors
                        on c.ColorId equals clr.Id
                             where b.Id == id
                    select new CarDetailDto { Id = c.Id, BrandName = b.Name, ColorName = clr.Name, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetailsByColor(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.Id
                    join clr in context.Colors
                        on c.ColorId equals clr.Id
                             where clr.Id == id
                    select new CarDetailDto { Id = c.Id, BrandName = b.Name, ColorName = clr.Name, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetailsByBrandAndColor(int brandId, int colorId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.Id
                    join clr in context.Colors
                        on c.ColorId equals clr.Id
                    where ((b.Id == brandId) && (clr.Id == colorId))
                             select new CarDetailDto { Id = c.Id, BrandName = b.Name, ColorName = clr.Name, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description };
                return result.ToList();
            }
        }
    }
}
