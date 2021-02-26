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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                                join c in context.Cars
                                    on r.CarId equals c.Id
                                    join b in context.Brands
                                        on c.BrandId equals b.Id
                                        join clr in context.Colors
                                            on c.ColorId equals clr.Id
                                            join cus in context.Customers
                                                on r.CustomerId equals cus.Id
                                                join  u in context.Users
                                                    on cus.UserId equals u.Id
                             select new RentalDetailDto{Id = r.Id, BrandName = b.Name, ColorName = clr.Name, CompanyName = cus.CompanyName, FirstName = u.FirstName, LastName = u.LastName, RentDate = r.RentDate, ReturnDate = r.ReturnDate};
                
                return result.ToList();
            }
        }
    }
}
