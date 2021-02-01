using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            ColorManager colorManager = new ColorManager(new InMemoryColorDal());
            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(brandManager.GetById(car.BrandId).BrandName + " " + colorManager.GetById(car.ColorId).ColorName);
                
            }
        }
    }
}
