using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult("Arac eklendi");

            }
            else
            {
                return new ErrorResult("Arac eklenemedi.Isim uzunlugunu ve diger bilgileri kontrol ediniz..");
            }


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
                return new ErrorResult("Arac guncellenemedi.");            }


        }
    }
}
