using Core.Utilities.Results.Abstract;
using Entities.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();

        IDataResult<List<Car>> GetCarsByColorId(int colorId);

        IDataResult<List<Car>> GetCarsByBrandId(int brandId);

        IResult Add(Car car);

        IResult Update(Car car);

        IResult Delete(Car car);

        IDataResult<List<CarDetailDto>> GetCarDetails();

    }
}
