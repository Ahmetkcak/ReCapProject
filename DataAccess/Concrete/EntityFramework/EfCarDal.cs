using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalDBContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var result = from c in context.Cars
                             join r in context.Colors
                             on c.ColorId equals r.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                 CarName = b.BrandName,
                                 ColorName = r.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
                              
            }
        }
    }
}
