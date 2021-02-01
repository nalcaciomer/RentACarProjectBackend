using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        private List<Brand> _brands;

        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand{Id = 1, BrandName = "Mercedes"},
                new Brand{Id = 2, BrandName = "BMW"},
                new Brand{Id = 3, BrandName = "Volvo"},
                new Brand{Id = 4, BrandName = "Audi"},
                new Brand{Id = 5, BrandName = "Dodge"},
            };
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }

        public Brand GetById(int brandId)
        {
            return _brands.SingleOrDefault(b=> b.Id == brandId);
        }

        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Update(Brand brand)
        {
            var brandToUpdate = _brands.SingleOrDefault(b=>b.Id == brand.Id);
            brandToUpdate.Id = brand.Id;
            brandToUpdate.BrandName = brand.BrandName;
        }

        public void Delete(Brand brand)
        {
            var brandToDelete = _brands.SingleOrDefault(b => b.Id == brand.Id);
            _brands.Remove(brandToDelete);
        }
    }
}
