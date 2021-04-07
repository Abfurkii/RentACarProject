using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetailsDto();
        List<CarDetailIdDto> GetCarDetailsWithIdsDto();
        List<CarDetailTryDto> GetCarDetailsTryDto();
        List<CarDetail> GetCarDetailsByBrandId(int brandId);
        List<CarDetail> GetCarDetailsByColorId(int colorId);
        List<CarDetail> GetCarDetailsByCarId(int carId);
        List<CarDetail> GetAllCarDetails();
        List<CarDetail> GetCarsByBrandIdAndColorId(int brandId, int colorId);
    }
}
