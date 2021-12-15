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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetDetails(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Customers
                    join u in context.Users
                        on c.UserId equals u.Id
                    select new CustomerDetailDto()
                    {
                        Id = c.Id,
                        UserFirstName = u.FirstName,
                        UserLastName = u.LastName,
                        CompanyName = c.CompanyName
                    };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}