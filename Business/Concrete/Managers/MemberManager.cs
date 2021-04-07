using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete.Managers
{
    public class MemberManager : IMemberService
    {
        private IMemberDal _memberDal;
        public MemberManager(IMemberDal memberDal)
        {
            _memberDal = memberDal;
        }
        public IResult Add(Member member)
        {
            _memberDal.Add(member);
            return new SuccessResult();
        }

        public IResult Delete(Member member)
        {
            _memberDal.Delete(member);
            return new SuccessResult(Messages.MemberDeleted);
        }

        public IDataResult<List<Member>> GetAll(Expression<Func<Member, bool>> filter = null)
        {
            var result = _memberDal.GetAll(filter);
            if (result==null)
            {
                return new ErrorDataResult<List<Member>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<Member>>(result);
        }

        public IDataResult<Member> GetByMail(string email)
        {
            return new SuccessDataResult<Member>(_memberDal.Get(m => m.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(Member member)
        {
            var result = _memberDal.GetClaims(member);
            if (result==null)
            {
                return new ErrorDataResult<List<OperationClaim>>(Messages.NotFound);
            }
            return new SuccessDataResult<List<OperationClaim>>(result, Messages.MemberFound);
        }

        public IResult Update(Member member)
        {
            _memberDal.Update(member);
            return new SuccessResult(Messages.Updated);
        }
    }
}
