using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;
        public CarManager(ICarDal carDal,IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }


        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {

            IResult result = BusinessRules.Run(
                CheckIfCarModelNameExists(car.Model),
                CheckIfCarCountOfBrand(car.BrandId),
                CheckIfBrandLimitExceded()
                );

            if (result!=null)
            {
                return result;
            }         
                    _carDal.Add(car);
                    return new SuccessResult(Messages.CarAdded);

        }
        private IResult CheckIfBrandLimitExceded()
        {
            var result = _brandService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.BrandLimitExceded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarModelNameExists(string model)
        {
            var result = _carDal.GetAll(c => c.Model == model).Any();
            if (result) 
            {
                return new ErrorResult(Messages.CarModelNameAlreadyExists);
            }
            return new SuccessResult();
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Arac silindi.");

        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult < List < Car >> (_carDal.GetAll(),"\n Arabalar listelendi.");
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max),"\n Fiyat araligina gore listelendi.");
        }

        public IDataResult<List<Car>> GetById(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.CarId == id),"ID'ye gore listelendi.");
        }

        public IDataResult<List<CarDetailDTO>> GetCarDetailDtos()
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails(),"aracın detayları listelendi.");
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id),"Marka ID'sine gore listelendi");
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id),"Renk ID'sine gore listelendi");
        }

        public IResult Update(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Update(car);
                return new SuccessResult("Arac guncellendi");
            }
            else
            {
                return new ErrorResult("Arac guncellenemedi.");           
            }


        }
        private IResult CheckIfCarCountOfBrand(int brandId) 
        {
            var result = _carDal.GetAll(c => c.BrandId ==brandId).Count;
            if (result > 10)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();

        }
    }
}
