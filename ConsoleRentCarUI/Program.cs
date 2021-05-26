using Business.Abstract;
using Business.Concrete.Managers;
using Business.DependencyResolvers.Ninject;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleRentCarUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICreditCardService creditCardService = new CreditCardManager(new EfCreditCardDal());

            creditCardService.Add(new CreditCard
            {
                MemberId = 2,
                Name = "TEB",
                CreditCardNumber="4402930026004816",
                Month=10,
                Year=2020,
                Ccv="264"
            });

        }
    }
}
