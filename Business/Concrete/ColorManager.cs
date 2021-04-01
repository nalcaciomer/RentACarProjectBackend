using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
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

        [SecuredOperation("color.add,admin")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        [SecuredOperation("color.update,admin")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Color color)
        {
            
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }

        [SecuredOperation("color.delete,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed);
        }

        [CacheAspect]
        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(clr=> clr.Id == colorId), Messages.ColorListed);
        }
    }
}
