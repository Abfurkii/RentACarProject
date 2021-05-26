using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using Core.Utilities.Business;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;

namespace Business.Concrete.Managers
{
    public class CreditCardManager : ICreditCardService
    {
        private ICreditCardDal _creditCardDal;
        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult(Messages.CreditCardAdded);
        }

        public IDataResult<List<CreditCard>> GetAll(Expression<Func<CreditCard, bool>> filter = null)
        {
            var result = _creditCardDal.GetAll(filter);
            if (result!=null)
            {
                return new SuccessDataResult<List<CreditCard>>(result);
            }
            return new ErrorDataResult<List<CreditCard>>(Messages.NoData);
        }

        public IDataResult<List<CreditCard>> GetAllByMemberId(int memberId)
        {
            var result = _creditCardDal.GetAll(c => c.MemberId == memberId);
            if (result.Count>0)
            {
                return new SuccessDataResult<List<CreditCard>>(result);
            }
            return new ErrorDataResult<List<CreditCard>>(Messages.NoData);
        }

        public IDataResult<CreditCard> GetByMemberId(int memberId)
        {
            var result = _creditCardDal.Get(c => c.MemberId == memberId);
            if (result!=null)
            {
                return new SuccessDataResult<CreditCard>(result);
            }
            return new ErrorDataResult<CreditCard>(Messages.NoData);
        }

        public IResult CardControl(CreditCard creditCard)
        {
            var result = _creditCardDal.Get(c => c.MemberId == creditCard.MemberId);
            if (result != null && result.CreditCardNumber == creditCard.CreditCardNumber && result.Month == creditCard.Month
                && result.Year == creditCard.Year && result.Name == creditCard.Name)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.NotFoundCard);
        }

        //public IResult MemberCardExist(int cardId)
        //{
        //    var result = _creditCardDal.GetAll(c => c.Id == cardId).Any();
        //    if (result)
        //    {
        //        return new SuccessResult();
        //    }
        //    return new ErrorResult(Messages.NoDataThisCardId);
        //}
        public IResult MemberCardExist(int memberId)
        {
            var result = _creditCardDal.GetAll(c => c.MemberId == memberId).Any();
            if (result)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.NoDataThisCardId);
        }

        
    }
}
