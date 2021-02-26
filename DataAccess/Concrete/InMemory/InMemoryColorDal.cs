using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                new Color{Id = 1, Name = "Siyah"},
                new Color{Id = 2, Name = "Beyaz"},
                new Color{Id = 3, Name = "Gri"},
                new Color{Id = 4, Name = "Kırmızı"},
                new Color{Id = 5, Name = "Mavi"}
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

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Color GetById(int colorId)
        {
            return _colors.SingleOrDefault(c => c.Id == colorId);
        }

        public void Update(Color color)
        {
            var colorToUpdate = _colors.SingleOrDefault(c => c.Id == color.Id);
            colorToUpdate.Id = color.Id;
            colorToUpdate.Name = color.Name;
        }
    }
}
