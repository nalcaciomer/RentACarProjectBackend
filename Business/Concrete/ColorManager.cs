using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (color.Name.Length >= 2)
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.ColorAdded);
            }

            return new ErrorResult(Messages.ColorNameInvalid);
        }

        public IResult Update(Color color)
        {
            if (color.Name.Length >= 2)
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.ColorUpdated);
            }

            return new ErrorResult(Messages.ColorNameInvalid);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(clr=> clr.Id == colorId));
        }
    }
}
