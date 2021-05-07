using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ECarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ECarContext  context=new ECarContext())
            {  
                var result=from c  in context.Cars
                           join b  in context.Brands
                            on c.BrandId equals b.BrandId
                            join r   in context.Colors
                             on c.ColorId equals r.ColorId
                             select new CarDetailDto
                             {
                                 CarId=c.CarId,
                                 CarName=c.CarName,
                                 BrandName=b.BrandName,
                                 ColorName=r.ColorName,
                                 DailyPrice=c.DailyPrice,
                                 ModelYear=c.ModelYear,
                                 Description=c.Description,
                                 ImagePath = (from a in context.CarImages where a.CarId == c.CarId select a.ImagePath).FirstOrDefault()

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}
