using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarImageDal : IEntityRepository<CarImage>
    {
        List<CarImage> GetImageByBrandId(int brandId);
        List<CarImage> GetImageByColorId(int colorId);
        List<CarImage> GetImageByBrandIdAndColorId(int brandId, int colorId);
    }
}
