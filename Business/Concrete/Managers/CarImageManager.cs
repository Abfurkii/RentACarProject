using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;

namespace Business.Concrete.Managers
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageCount(carImage.CarId));
            if (result != null)
            {
                return new ErrorResult(Messages.OverImage);
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = FileHelper.Delete(carImage.ImagePath);
            if (result != null)
            {
                return new ErrorResult(Messages.ThrowErrorMessage);
            }
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            if (id == 0)
            {
                return new ErrorDataResult<List<CarImage>>();
            }
            var result = _carImageDal.GetAll(c => c.CarId == id);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }
            return new SuccessDataResult<List<CarImage>>(DefaultIfImageNull());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarId == id));
        }
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(c => c.CarId == carImage.CarId).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckCarImageCount(int carId)
        {
            var result = _carImageDal.GetAll(x => x.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        public IDataResult<List<CarImage>> GetImageByBrandId(int brandId)
        {
            if (brandId == 0)
            {
                return new ErrorDataResult<List<CarImage>>();
            }
            var result = _carImageDal.GetImageByBrandId(brandId);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }
            return new SuccessDataResult<List<CarImage>>(DefaultIfImageNull());
        }
        public IDataResult<List<CarImage>> GetImageByColorId(int colorId)
        {
            if (colorId == 0)
            {
                return new ErrorDataResult<List<CarImage>>();
            }
            var result = _carImageDal.GetImageByColorId(colorId);
            if (result.Count > 0)
            {
                return new SuccessDataResult<List<CarImage>>(result);
            }
            return new SuccessDataResult<List<CarImage>>(DefaultIfImageNull());
        }
        public List<CarImage> DefaultIfImageNull()
        {
            //List<CarImage> carImage = _carImageDal.GetAll(c => c.CarId == id);
            var path = @"\DefaultImage.png";
            var result = new List<CarImage> {new CarImage
            {
                ImagePath=path
            }};
            return result;
        }

        
    }
}
