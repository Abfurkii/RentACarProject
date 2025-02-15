﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMemberDal : EfEntityRepositoryBase<Member, RentCarContext>, IMemberDal
    {
        public List<OperationClaim> GetClaims(Member member)
        {
            using (var context=new RentCarContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join memberOperationClaim in context.MemberOperationClaims
                             on operationClaim.Id equals memberOperationClaim.OperationClaimId
                             where memberOperationClaim.MemberId == member.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
                return result.ToList();
            }
        }

        public List<MemberDto> GetMemberByEmail(string email)
        {
            using (RentCarContext context=new RentCarContext())
            {
                var result = from m in context.Members
                             where m.Email == email
                             select new MemberDto
                             {
                                 Id = m.Id,
                                 Email = m.Email,
                                 FirstName = m.FirstName,
                                 LastName = m.LastName
                             };
                return result.ToList();
            }
        }
    }
}
