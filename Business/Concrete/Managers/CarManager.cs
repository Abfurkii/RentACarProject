using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using Business.Constants;
using Core.CrossCuttingConcern.Validation;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Autofac.Caching;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Performance;
using System.Transactions;
using Core.Aspects.Autofac.Transaction;
using System.Threading;

namespace Business.Concrete.Managers
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheRemoveAspect("Product.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<Car> Get(int id)
        {
            var result = _carDal.Get(c => c.Id == id);
            if (result != null)
            {
                return new SuccessDataResult<Car>(result);
            }
            return new ErrorDataResult<Car>(Messages.NoData);
        }

        [PerformanceAspect(5)]
        //[SecuredOperation("car.getall,admin")]
        [CacheAspect(60)]
        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(filter));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDtos()
        {
            if (DateTime.Now.Hour == 03)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.WithoutWork);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsDto());
        }

        public IDataResult<List<CarDetailIdDto>> GetCarDetailsWithIdsDtos()
        {
            return new SuccessDataResult<List<CarDetailIdDto>>(_carDal.GetCarDetailsWithIdsDto());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            var result = _carDal.GetAll(x => x.BrandId == brandId);
            if (result.Count <= 0)
            {
                return new ErrorDataResult<List<Car>>(Messages.NoData);
            }
            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<CarDetail>> GetCarDetailsByColorId(int colorId)
        {
            var result = _carDal.GetCarDetailsByColorId(colorId);
            if (result.Count <= 0)
            {
                return new ErrorDataResult<List<CarDetail>>(Messages.NoData);
            }
            return new SuccessDataResult<List<CarDetail>>(result);
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        [TransactionScopeAspect]
        public IResult TransactionTest(Car myCar, Car yourCar)
        {
            _carDal.Add(myCar);
            _carDal.Add(yourCar);
            return new SuccessResult(Messages.SuccessProcess);
        }

        public IDataResult<List<CarDetailTryDto>> GetCarDetailsTryDtos()
        {
            return new SuccessDataResult<List<CarDetailTryDto>>(_carDal.GetCarDetailsTryDto());
        }

        public IDataResult<List<CarDetail>> GetCarDetailsByBrandId(int id)
        {
            var result = _carDal.GetCarDetailsByBrandId(id);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarDetail>>(result);
            }
            return new ErrorDataResult<List<CarDetail>>(Messages.NoData);
        }

        public IDataResult<List<CarDetail>> GetAllCarDetails()
        {
            var result = _carDal.GetAllCarDetails();
            if (result.Count>0)
            {
                return new SuccessDataResult<List<CarDetail>>(result);
            }
            return new ErrorDataResult<List<CarDetail>>(Messages.NoData);
        }

        public IDataResult<List<CarDetail>> GetCarDetailsByCarId(int carId)
        {
            var result = _carDal.GetCarDetailsByCarId(carId);
            if (result!=null)
            {
                return new SuccessDataResult<List<CarDetail>>(result);
            }
            return new ErrorDataResult<List<CarDetail>>(Messages.NoData);
        }

        public IDataResult<List<CarDetail>> GetCarsByBrandIdAndColorId(int brandId, int colorId)
        {
            var result = _carDal.GetCarsByBrandIdAndColorId(brandId,colorId);
            if (result != null)
            {
                return new SuccessDataResult<List<CarDetail>>(result);
            }
            return new ErrorDataResult<List<CarDetail>>(Messages.NoData);
        }
    }
}
