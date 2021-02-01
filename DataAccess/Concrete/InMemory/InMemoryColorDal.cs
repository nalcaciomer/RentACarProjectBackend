using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        private List<Color> _colors;

        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color{Id = 1, ColorName = "Siyah"},
                new Color{Id = 2, ColorName = "Beyaz"},
                new Color{Id = 3, ColorName = "Gri"},
                new Color{Id = 4, ColorName = "Kırmızı"},
                new Color{Id = 5, ColorName = "Mavi"}
            };
        }
        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Delete(Color color)
        {
            var colorToDelete = _colors.SingleOrDefault(c => c.Id == color.Id);
            _colors.Remove(colorToDelete);
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public Color GetById(int colorId)
        {
            return _colors.SingleOrDefault(c => c.Id == colorId);
        }

        public void Update(Color color)
        {
            var colorToUpdate = _colors.SingleOrDefault(c => c.Id == color.Id);
            colorToUpdate.Id = color.Id;
            colorToUpdate.ColorName = color.ColorName;
        }
    }
}
