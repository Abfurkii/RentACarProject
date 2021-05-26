using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete.Managers
{
    public class PaymentManager : IPaymentService
    {
        private IPaymentDal _paymentDal;
        private ICreditCardService _creditCardService;
        public PaymentManager(IPaymentDal paymentDal, ICreditCardService creditCardService)
        {
            _paymentDal = paymentDal;
            _creditCardService = creditCardService;
        }
        [ValidationAspect(typeof(PaymentValidator))]
        public IResult Add(Payment payment)
        {
            var result = _creditCardService.MemberCardExist(payment.MemberId);

            if (result.Success)
            {
                if (payment.ProcessDate == null)
                    payment.ProcessDate = DateTime.Now;

                _paymentDal.Add(payment);
                return new SuccessResult(Messages.PaymentAdded);
            }
            return new ErrorResult(result.Message);
        }

        public IDataResult<List<Payment>> GetAll(Expression<Func<Payment, bool>> filter = null)
        {
            var result = _paymentDal.GetAll(filter);
            if (result != null)
            {
                return new SuccessDataResult<List<Payment>>(result);
            }
            return new ErrorDataResult<List<Payment>>(Messages.NoData);
        }
    }
}
