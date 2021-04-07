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
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
        public List<CarDetail> GetAllCarDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join clr in context.Colors on c.ColorId equals clr.Id
                             select new CarDetail
                             {
                                 CarId = c.Id,
                                 ColorId = clr.Id,
                                 BrandId = b.Id,
                                 BrandName = b.BrandName,
                                 ColorName = clr.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }

        public List<CarDetail> GetCarDetailsByBrandId(int brandId)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join clr in context.Colors on c.ColorId equals clr.Id
                             where c.BrandId == brandId
                             select new CarDetail
                             {
                                 CarId = c.Id,
                                 ColorId = clr.Id,
                                 BrandId = b.Id,
                                 BrandName = b.BrandName,
                                 ColorName = clr.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }

        public List<CarDetail> GetCarDetailsByCarId(int carId)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join clr in context.Colors on c.ColorId equals clr.Id
                             where c.Id == carId
                             select new CarDetail
                             {
                                 CarId = c.Id,
                                 ColorId = clr.Id,
                                 BrandId = b.Id,
                                 BrandName = b.BrandName,
                                 ColorName = clr.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }

        public List<CarDetail> GetCarDetailsByColorId(int colorId)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join clr in context.Colors on c.ColorId equals clr.Id
                             where c.ColorId == colorId
                             select new CarDetail
                             {
                                 CarId = c.Id,
                                 ColorId = clr.Id,
                                 BrandId = b.Id,
                                 BrandName = b.BrandName,
                                 ColorName = clr.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsDto()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join clr in context.Colors
                             on c.ColorId equals clr.Id
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = clr.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }

        public List<CarDetailTryDto> GetCarDetailsTryDto()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join clr in context.Colors
                             on c.ColorId equals clr.Id
                             select new CarDetailTryDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = clr.ColorName
                             };
                return result.ToList();
            }
        }

        public List<CarDetailIdDto> GetCarDetailsWithIdsDto()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join clr in context.Colors
                             on c.ColorId equals clr.Id
                             select new CarDetailIdDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId,
                                 ColorName = clr.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }


        public List<CarDetail> GetCarsByBrandIdAndColorId(int brandId,int colorId)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join clr in context.Colors
                             on c.ColorId equals clr.Id
                             where b.Id==brandId && clr.Id==colorId
                             select new CarDetail
                             {
                                 CarId = c.Id,
                                 ColorId = clr.Id,
                                 BrandId = b.Id,
                                 BrandName = b.BrandName,
                                 ColorName = clr.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }
    }
}
