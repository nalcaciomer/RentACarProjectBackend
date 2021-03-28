using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer{CompanyName = "Laptop Hospital", UserId = 1});

            foreach (var customer in customerManager.GetCustomerDetails().Data)
            {
                Console.WriteLine("Id= {0} - FirstName= {1} - LastName= {2} - CompanyName= {3}" , customer.Id, customer.UserFirstName, customer.UserLastName, customer.CompanyName);
            }
        }
    }
}
