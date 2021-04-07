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
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = RentalCarControl(rental.CarId);
            if (!result.Success)
            {
                return new ErrorResult(Messages.RentalNotDelivered);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IDataResult<List<Rental>> GetAll(Expression<Func<Rental,bool>> filter=null)
        {
            var result = _rentalDal.GetAll(filter);
            if (result.Count<1)
            {
                return new ErrorDataResult<List<Rental>>(Messages.NoData);
            }
            return new SuccessDataResult<List<Rental>>(result);
        }

        public IDataResult<List<RentalDetail>> GetRentalDetails()
        {
            var result = _rentalDal.GetRentalDetail();
            if (result.Count>0)
            {
                return new SuccessDataResult<List<RentalDetail>>(result);
            }
            return new ErrorDataResult<List<RentalDetail>>(Messages.NoData);
        }

        public IResult RentalCarControl(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null).Any();
            if (result)
            {
                return new ErrorResult(Messages.RentalNotDelivered);
            }
            return new SuccessResult();
        }
    }
}
