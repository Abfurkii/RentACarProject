using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMemberDal : IEntityRepository<Member>
    {
        List<OperationClaim> GetClaims(Member member);
        List<MemberDto> GetMemberByEmail(string email);
    }
}
