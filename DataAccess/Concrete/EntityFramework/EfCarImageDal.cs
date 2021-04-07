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
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, RentCarContext>, ICarImageDal
    {
        public List<CarImage> GetImageByBrandId(int brandId)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from i in context.CarImages
                             join c in context.Cars on i.CarId equals c.Id
                             where c.BrandId == brandId
                             select i;
                return result.ToList();
            }
        }

        public List<CarImage> GetImageByColorId(int colorId)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from i in context.CarImages
                             join c in context.Cars on i.CarId equals c.Id
                             join clr in context.Colors on c.ColorId equals clr.Id
                             where clr.Id==colorId
                             select i;
                return result.ToList();
            }
        }
    }
}
