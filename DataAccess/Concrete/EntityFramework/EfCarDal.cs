using Azure.Identity;
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
using System.Threading.Tasks;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfCarProjectRepositoryBase<Car, CarProjectContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (CarProjectContext context = new CarProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandID equals b.BrandId
                             join c1 in context.Color
                             on c.ColorID equals c1.ColorId
                             select new CarDetailsDto
                             {
                                 CarName = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = c1.ColorName,
                                 DailyPrice = c.DailyPrice

                             };

                return result.ToList();
            }
        }

       
    }
}
