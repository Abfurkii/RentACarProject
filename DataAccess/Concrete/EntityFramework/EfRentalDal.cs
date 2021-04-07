using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
        public List<RentalDetail> GetRentalDetail()
        {
            using (RentCarContext context=new RentCarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join clr in context.Colors on c.ColorId equals clr.Id
                             join cus in context.Customers on r.CustomerId equals cus.Id
                             join u in context.Users on cus.UserId equals u.Id
                             select new RentalDetail
                             {
                                 CarId = c.Id,
                                 BrandName = b.BrandName,
                                 Description = c.Description,
                                 CustomerId = cus.Id,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 ColorName=clr.ColorName,
                                 DailyPrice=c.DailyPrice
                             };
                return result.ToList();
            }
        }

        public List<RentalDetailDto> GetRentalDetailDtos()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Customers on r.CustomerId equals c.Id
                             join u in context.Users on c.UserId equals u.Id
                             join car in context.Cars on r.CarId equals car.Id
                             join b in context.Brands on car.BrandId equals b.Id
                             select new RentalDetailDto
                             {
                                 BrandName = b.BrandName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName
                             };
                return result.ToList();
            }
        }
    }
}
