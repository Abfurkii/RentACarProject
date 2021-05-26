using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IMemberService
    {
        IDataResult<List<OperationClaim>> GetClaims(Member member);
        IDataResult<Member> GetByMail(string email);
        IDataResult<MemberDto> GetMemberDtoByEmail(string email);
        IDataResult<List<Member>> GetAll(Expression<Func<Member,bool>> filter=null);
        IResult Add(Member member);
        IResult Update(Member member);
        IResult Delete(Member member);
    }
}
