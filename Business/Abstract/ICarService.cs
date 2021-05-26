using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{//GetCarsByBrandId , GetCarsByColorId servislerini yazınız.
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll(Expression<Func<Car,bool>> filter=null);
        IDataResult<Car> Get(int id);
        IResult Add(Car car);
        IResult Update(Car car);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetail>> GetCarDetailsByCarId(int carId);
        IDataResult<List<CarDetail>> GetCarDetailsByColorId(int colorId);
        IResult TransactionTest(Car myCar, Car yourCar);
        IDataResult<List<CarDetail>> GetCarDetailsByBrandId(int id);
        IDataResult<List<CarDetail>> GetAllCarDetails();
        IDataResult<List<CarDetail>> GetCarsByBrandIdAndColorId(int brandId, int colorId);
        
    }
}
