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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Customers
                                                        join u in context.Users
                                                        on c.UserId equals u.Id
                                                        select new CustomerDetailDto { Id = c.Id, UserFirstName = u.FirstName, UserLastName = u.LastName, CompanyName = c.CompanyName };

                return result.ToList();
            }
        }
    }
}
