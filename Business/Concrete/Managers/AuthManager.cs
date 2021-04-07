using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete.Managers
{
    public class AuthManager : IAuthService
    {
        private IMemberService _memberService;
        private ITokenHelper _tokenHelper;
        public AuthManager(IMemberService memberService,ITokenHelper tokenHelper)
        {
            _memberService = memberService;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(Member member)
        {
            var claims = _memberService.GetClaims(member);
            var accessToken = _tokenHelper.CreateToken(member, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.CreatedAccessToken);
        }

        public IDataResult<Member> Login(MemberForLoginDto memberForLoginDto)
        {
            var checkMember = _memberService.GetByMail(memberForLoginDto.Email);
            if (checkMember.Data==null)
            {
                return new ErrorDataResult<Member>(Messages.NotFound);
            }

            var result = HashingHelper.VerifyPasswordHash(memberForLoginDto.Password, checkMember.Data.PasswordHash, checkMember.Data.PasswordSalt);
            if (!result)
            {
                return new ErrorDataResult<Member>(Messages.WrongPassword);
            }
            return new SuccessDataResult<Member>(checkMember.Data,Messages.TruePassword);
        }

        public IResult MemberExists(string email)
        {
            var result = _memberService.GetByMail(email);
            if (result.Data!=null)
            {
                return new ErrorResult(Messages.MemberAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<Member> Register(MemberForRegisterDto memberForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(memberForRegisterDto.Password, out passwordHash, out passwordSalt);
            var member = new Member
            {
                FirstName = memberForRegisterDto.FirstName,
                LastName = memberForRegisterDto.LastName,
                Email = memberForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _memberService.Add(member);
            return new SuccessDataResult<Member>(member, Messages.MemberAdded);
        }
    }
}
