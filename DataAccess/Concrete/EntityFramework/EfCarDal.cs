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

        public List<CarDetailDto> GetCarsDetailsByBrand(string brandName)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.Id
                    join clr in context.Colors
                        on c.ColorId equals clr.Id
                             where b.Name == brandName
                    select new CarDetailDto { Id = c.Id, BrandName = b.Name, ColorName = clr.Name, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetailsByColor(string colorName)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.Id
                    join clr in context.Colors
                        on c.ColorId equals clr.Id
                             where clr.Name == colorName
                    select new CarDetailDto { Id = c.Id, BrandName = b.Name, ColorName = clr.Name, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetailsByBrandAndColor(string brandName, string colorName)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands
                        on c.BrandId equals b.Id
                    join clr in context.Colors
                        on c.ColorId equals clr.Id
                    where b.Name == brandName && clr.Name == colorName
                             select new CarDetailDto { Id = c.Id, BrandName = b.Name, ColorName = clr.Name, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description };
                return result.ToList();
            }
        }
    }
}
