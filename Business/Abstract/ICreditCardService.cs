using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IResult Add(CreditCard creditCard);
        IDataResult<List<CreditCard>> GetAll(Expression<Func<CreditCard,bool>> filter=null);
        IDataResult<List<CreditCard>> GetAllByMemberId(int memberId);
        IDataResult<CreditCard> GetByMemberId(int memberId);
        IResult MemberCardExist(int cardNumber);
        IResult CardControl(CreditCard creditCard);
    }
}
