using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete.Managers
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            var result = _brandDal.Get(b => b.Id == brandId);
            if (result!=null)
            {
                return new SuccessDataResult<Brand>(result);
            }
            return new ErrorDataResult<Brand>(Messages.ThrowErrorMessage);
        }

        public IDataResult<List<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            var result = _brandDal.GetAll(filter);
            if (result.Count<1)
            {
                return new ErrorDataResult<List<Brand>>(Messages.NoData);
            }
            return new SuccessDataResult<List<Brand>>(result);
        }
    }
}
