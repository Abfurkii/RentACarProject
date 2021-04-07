using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<Member> Register(MemberForRegisterDto memberForRegisterDto);
        IDataResult<Member> Login(MemberForLoginDto memberForLoginDto);
        IResult MemberExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Member member);
    }
}
