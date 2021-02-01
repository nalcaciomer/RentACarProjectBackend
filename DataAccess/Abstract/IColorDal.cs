using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IColorDal
    {
        List<Color> GetAll();
        Color GetById(int colorId);
        void Add(Color color);
        void Update(Color color);
        void Delete(Color color);
    }
}
