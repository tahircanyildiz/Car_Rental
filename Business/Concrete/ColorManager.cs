using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult("Renk ismi en az 2 karakter olmalidir");
            }
            else
            {
                _colorDal.Add(color);
                return new SuccessResult("renk eklendi.");
            }
            
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult("renk silindi");
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new DataResult<List<Color>>( _colorDal.GetAll(),true,"Renkler listelendi");
        }

        public IDataResult<List<Color>> GetByColorId(int id)
        {
            return new DataResult<List<Color>>(_colorDal.GetAll(c => c.ColorId == id),true);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine("{0} Id'li Renk Güncellenmiştir", color.ColorId);
            return new SuccessResult();
        }
    }
}
