using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        IImageDal _carImageDal;
        public CarImageManager(IImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(_carImageDal.GetAll());
        }

        public IDataResult<List<Image>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Image>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<Image> GetByImageId(int id)
        {
            return new SuccessDataResult<Image>(_carImageDal.Get(c => c.Id == id));
        }

        public IResult Add(IFormFile file, Image carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
           // carImage.ImagePath =FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("Resim eklendi. ");
        }

        public IResult Delete(Image carImage)
        {
            IResult result = BusinessRules.Run(CarImageDelete(carImage));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, Image carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.Date = DateTime.Now;
            string oldPath = GetByImageId(carImage.Id).Data.ImagePath;
           // carImage.ImagePath =FileHelper.Update(oldPath, file);
            return new SuccessResult();
        }
        private IResult CheckIfImageLimitExceeded(int carId)
        {
            var carImageCount = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (carImageCount >= 15)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        private List<Image> CheckIfCarImageNull(int carId)
        {
            string path = @"DefaultImage.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                return new List<Image> { new Image { CarId = carId, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.CarId == carId);
        }

        private IResult CarImageDelete(Image carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
    }
}
